using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public static float Pace;
    [SerializeField] private Rigidbody Rb;
    [SerializeField] private Transform vector_back;
    [SerializeField] private Transform vector_forward;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject comp_panel;
    [SerializeField] private Image _image;
    private Touch _Touch;
    private bool touched = false;
    [SerializeField] private AudioClip[] clips;
    private void Start()
    {
        Pace = 30;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (PlayerPrefs.GetInt("vib") == 0)
            {
                Vibration.Vibrate(50);
            }
            AudioSource.PlayClipAtPoint(clips[3], transform.position);
            StartCoroutine("GameOverPanel");
        }
        if (collision.gameObject.CompareTag("Touchable"))
        {
            AudioSource.PlayClipAtPoint(clips[2], transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            comp_panel.SetActive(true);
            ButtonManager.allow = false;
            AudioSource.PlayClipAtPoint(clips[0], transform.position);
            Time.timeScale = 0;
        }
        if (other.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(0);
            ButtonManager.allow = false;
        }
    }
    void FixedUpdate()
    {
        if (ButtonManager.allow)
        {
            if (touched)
            {
                transform.Translate(Vector3.forward * Pace * Time.deltaTime);
                vector_forward.Translate(Vector3.forward * Pace * Time.deltaTime);
                vector_back.Translate(Vector3.forward * Pace * Time.deltaTime);
            }
            if (Input.touchCount > 0)
            {
                _Touch = Input.GetTouch(0);
                if (_Touch.phase == TouchPhase.Began)
                {
                    touched = true;
                }
                else if (_Touch.phase == TouchPhase.Moved)
                {
                    Rb.velocity = new Vector3(_Touch.deltaPosition.x * Pace * Time.deltaTime, transform.position.y, _Touch.deltaPosition.y * Pace * Time.deltaTime);
                }
                else if (_Touch.phase == TouchPhase.Ended)
                {
                    Rb.velocity = Vector3.zero;
                }
            }
        }
        _image.fillAmount = (200 - (100 - transform.position.z)) / 200;// [bütün yol-(son nokta-mevcut nokta)] / %200deki oraný
    }
    private IEnumerator GameOverPanel()
    {
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(.5f);
        _panel.SetActive(true);
        AudioSource.PlayClipAtPoint(clips[1], transform.position);
        Time.timeScale = 0;
    }
}