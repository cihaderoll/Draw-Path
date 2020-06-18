using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anaMenuKontrol : MonoBehaviour
{
    oyunKontrol kontrol;

    public Button yesButton;
    public Sprite pressedSprite;
    public Sprite releasedSprite;
    public GameObject exitPanel;
    public Text levelCountText;
    public Text totalScoreText;

    public AudioSource exitGame;
    public AudioSource backGround;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        levelCountText.text = "" + PlayerPrefs.GetInt("levelKayit", 1);
        totalScoreText.text = "" + PlayerPrefs.GetInt("highScore", 0);
        //---------------------MUSIC-----------------------
        if (PlayerPrefs.GetInt("isMusicOn", 1) == 1)
        {
            backGround.Play();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("isMusicOn", 1) == 0)
        {
            backGround.Stop();
        }
        else if(PlayerPrefs.GetInt("isMusicOn", 1) == 1)
        {
            if (!(backGround.isPlaying))
            {
                backGround.Play();
            }
        }
    }

    public void exitEvent()
    {
        if (PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            exitGame.Play();
        }
        exitPanel.SetActive(true);
    }

    public void exitReturn()
    {
        if (PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            exitGame.Play();
        }

        exitPanel.SetActive(false);
    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void start()
    {
        for(int i =0; i<=10; i++)
        {
            if(PlayerPrefs.GetInt("levelKayit", 1) == i)
            {
                SceneManager.LoadScene("level" + i);
            }
        }
        
    }

    public void levelmenu()
    {
        
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("levelMenu");
    }
}
