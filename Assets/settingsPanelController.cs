using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsPanelController : MonoBehaviour
{
    public static settingsPanelController instantiate;

    public GameObject settingsPanel;
    public Text soundText;
    public Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button soundButton;

    public Text musicText;
    public GameObject musicOff;
    public Button musicButton;

    public AudioSource settingSound;


    public bool isMusicOn = true;


    int i = 0;
    int j = 0;

    private void Awake()
    {
        instantiate = this;
    }
    void Start()
    {
        if(PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            soundText.text = "Sound on";
            soundButton.GetComponent<Image>().sprite = soundOnImage;
        }
        else
        {
            soundText.text = "Sound off";
            soundButton.GetComponent<Image>().sprite = soundOffImage;
            i++;
        }
        //--------------SOUND-----------------------------
        if (PlayerPrefs.GetInt("isMusicOn", 1) == 1)
        {
            musicText.text = "Music on";
            musicOff.SetActive(false);
        }
        else
        {
            musicText.text = "Music off";
            musicOff.SetActive(true);
            i++;
        }
        //---------------------MUSIC--------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitSettingsPanel()
    {
        if (PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            settingSound.Play();
        }
        settingsPanel.SetActive(false);
    }

    public void enterSettingsPanel()
    {
        if (PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            settingSound.Play();
        }       
        settingsPanel.SetActive(true);
    }

    public void soundButtonControl()
    {
        if(i%2== 0)
        {
            soundText.text = "Sound off";
            PlayerPrefs.SetInt("isSoundOn", 0);
            i++;
            soundButton.GetComponent<Image>().sprite = soundOffImage;
        }
        else
        {
            soundText.text = "Sound on";
            PlayerPrefs.SetInt("isSoundOn", 1);
            soundButton.GetComponent<Image>().sprite =soundOnImage;
            i++;
        }
    }

    public void mısicButtonControl()
    {
        if (j % 2 == 0)
        {
            PlayerPrefs.SetInt("isMusicOn", 0);
            musicText.text = "Music off";
            musicOff.SetActive(true);
            j++;    
        }
        else
        {
            PlayerPrefs.SetInt("isMusicOn", 1);
            musicText.text = "Music on";
            musicOff.SetActive(false);
            j++;
        }
    }
}
