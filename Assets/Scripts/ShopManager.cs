using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject[] selected;
    [SerializeField] private GameObject[] effects;
    [SerializeField] private TextMeshProUGUI[] texts;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("itemSelect"))
            PlayerPrefs.SetInt("itemSelect", 0);
        
        if (!PlayerPrefs.HasKey("click1"))
            PlayerPrefs.SetString("click1", "false");
        
        if (!PlayerPrefs.HasKey("click2"))
            PlayerPrefs.SetString("click2", "false");
        
        EffectControl();
    }
    public void EffectSelect(int num)
    {
        if (num==0)
        {
            selected[0].SetActive(true);
            selected[1].SetActive(false);
            selected[2].SetActive(false);
            effects[0].SetActive(true);
            effects[1].SetActive(false);
            effects[2].SetActive(false);
            PlayerPrefs.SetInt("itemSelect", 0);
        }
        if (num == 1)
        {
            if (PlayerPrefs.GetInt("level") >= 2)
            {
                selected[0].SetActive(false);
                selected[1].SetActive(true);
                selected[2].SetActive(false);
                effects[0].SetActive(false);
                effects[1].SetActive(true);
                effects[2].SetActive(false);
                texts[0].text = "Owned";
                PlayerPrefs.SetInt("itemSelect", 1);
                PlayerPrefs.SetString("click1", "true");
            }
        }
        if (num == 2)
        {
            if (PlayerPrefs.GetInt("level") >= 3)
            {
                selected[0].SetActive(false);
                selected[1].SetActive(false);
                selected[2].SetActive(true);
                effects[0].SetActive(false);
                effects[1].SetActive(false);
                effects[2].SetActive(true);
                texts[1].text = "Owned";
                PlayerPrefs.SetInt("itemSelect", 2);
                PlayerPrefs.SetString("click2", "true");
            }
        }
    }
    public void EffectControl()
    {
        if (PlayerPrefs.GetInt("itemSelect")==0)
        {
            selected[0].SetActive(true);
            selected[1].SetActive(false);
            selected[2].SetActive(false);
            effects[0].SetActive(true);
            effects[1].SetActive(false);
            effects[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("itemSelect") == 1)
        {
            selected[0].SetActive(false);
            selected[1].SetActive(true);
            selected[2].SetActive(false);
            effects[0].SetActive(false);
            effects[1].SetActive(true);
            effects[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("itemSelect") == 2)
        {
            selected[0].SetActive(false);
            selected[1].SetActive(false);
            selected[2].SetActive(true);
            effects[0].SetActive(false);
            effects[1].SetActive(false);
            effects[2].SetActive(true);
        }

        if (PlayerPrefs.GetString("click1") == "true")
            texts[0].text = "Owned";
        
        if (PlayerPrefs.GetString("click2") == "true")
            texts[1].text = "Owned";
    }
}