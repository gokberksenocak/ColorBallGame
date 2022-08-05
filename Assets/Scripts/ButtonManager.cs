using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private int clicked = 0;
    public static bool allow = false;
    private Scene _scene;
    private GameObject music;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject buttonA;
    [SerializeField] private GameObject buttonB;
    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
        music = GameObject.FindGameObjectWithTag("Music");
        if (PlayerPrefs.GetInt("music") == 0)
        {
            button1.SetActive(true);
            button2.SetActive(false);
            music.GetComponent<AudioSource>().enabled = true;
        }
        if (PlayerPrefs.GetInt("music") == 1)
        {
            button2.SetActive(true);
            button1.SetActive(false);
            music.GetComponent<AudioSource>().enabled = false;
        }
        if (PlayerPrefs.GetInt("vib") == 0)
        {
            buttonA.SetActive(true);
            buttonB.SetActive(false);
        }
        if (PlayerPrefs.GetInt("vib") == 1)
        {
            buttonB.SetActive(true);
            buttonA.SetActive(false);
        }
    }
    public void AnimControls()
    {
        clicked++;
        if (clicked%2==1)
        {
           _animator.SetBool("opened", true);
        }
        else
        {
            _animator.SetBool("opened", false); 
        }
    }
    public void MusicOn()
    {
        PlayerPrefs.SetInt("music", 1);
        button2.SetActive(true);
        button1.SetActive(false);
        music.GetComponent<AudioSource>().enabled = false;
    }
    public void MusicOff()
    {
        PlayerPrefs.SetInt("music", 0);
        button1.SetActive(true);
        button2.SetActive(false);
        music.GetComponent<AudioSource>().enabled = true;
    }
    public void VibOn()
    {
        PlayerPrefs.SetInt("vib", 1);
        buttonB.SetActive(true);
        buttonA.SetActive(false);
    }
    public void VibOff()
    {
        PlayerPrefs.SetInt("vib", 0);
        buttonA.SetActive(true);
        buttonB.SetActive(false);
    }
    public void Starting()
    {
        StartPanel.SetActive(false);
        allow = true;
    }
    public void Restart()
    {
        allow = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(_scene.buildIndex);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}