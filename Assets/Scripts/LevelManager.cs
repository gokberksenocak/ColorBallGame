using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject lv2;
    [SerializeField] private GameObject lv3;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level3;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
        LevelControl();
    }
    public void LevelControl()
    {
        if (PlayerPrefs.GetInt("level") == 2)
        {
            lv2.SetActive(false);
            level2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("level") == 3)
        {
            lv2.SetActive(false);
            level2.SetActive(true);
            lv3.SetActive(false);
            level3.SetActive(true);
        }
    }
    public void Levels(int Index)
    {
        if (Index==1)
        {
            SceneManager.LoadScene(1);
        }
        if (Index == 2)
        {
            SceneManager.LoadScene(2);
        }
        if (Index == 3)
        {
            SceneManager.LoadScene(3);
        }
    }
}