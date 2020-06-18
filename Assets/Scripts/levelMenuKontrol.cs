using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMenuKontrol : MonoBehaviour
{

    public AudioSource backGround;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("isMusicOn", 1) == 1)
        {
            backGround.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void level1()
    {
        SceneManager.LoadScene("level1");
    }

    public void level2()
    {
        if(PlayerPrefs.GetInt("levelKayit", 1) >= 2)
        {
            SceneManager.LoadScene("level2");
        }    
    }

    public void level3()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 3)
        {
            SceneManager.LoadScene("level3");
        }
    }

    public void level4()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 4)
        {
            SceneManager.LoadScene("level4");
        }
    }

    public void level5()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 5)
        {
            SceneManager.LoadScene("level5");
        }
    }
    public void level6()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 6)
        {
            SceneManager.LoadScene("level6");
        }
    }
    public void level7()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 7)
        {
            SceneManager.LoadScene("level7");
        }
    }
    public void level8()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 8)
        {
            SceneManager.LoadScene("level8");
        }
    }
    public void level9()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 9)
        {
            SceneManager.LoadScene("level9");
        }
    }
    public void level10()
    {
        if (PlayerPrefs.GetInt("levelKayit", 1) >= 10)
        {
            SceneManager.LoadScene("level10");
        }
    }

    public void homeButton()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
        
    }
}
