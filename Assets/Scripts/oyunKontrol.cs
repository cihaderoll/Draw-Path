using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunKontrol : MonoBehaviour
{
    public static oyunKontrol instantiate;

    
    public GameObject ball;
    public Rigidbody2D fizik;
    public GameObject gameOverPanel;
    public GameObject levelPassPanel;

    public Slider slider;


    public int ınkLevel = 100;
    public bool isFree = false;
    public bool gameOver = false;
    public float totalDistance = 15f;
    public bool draw = true;
    public int levelCount;
    public int score = 0;
    public int totalScore;
    public bool starCollected = true;

    public AudioSource buttonSound;
    public AudioSource backGround;




    private void Awake()
    {
        instantiate = this;
    }

    public bool stop = true;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        fizik = ball.GetComponent<Rigidbody2D>();
        for(int i =1; i<=10; i++)
        {
            totalScore += PlayerPrefs.GetInt("levelScoreKayit" + i, 0);

        }
        PlayerPrefs.SetInt("highScore", totalScore);

        if (PlayerPrefs.GetInt("isMusicOn", 1) == 1)
        {
            backGround.Play();
        }
    }


    void Update()
    {
        //ınkLevelText.text = "" + ınkLevel;

        if (fizik.velocity != Vector2.zero)
        {
            isFree = true;
        }

        if (fizik.gravityScale == 3 && fizik.velocity == Vector2.zero && isFree)
        {
            gameOver = true;
            Invoke("gameOver1", 0.5f);
        }
        slider.value = totalDistance / 15f;
    }

    public void BaslamaDurdurma()
    {
        //stop = !stop;
        if (PlayerPrefs.GetInt("isSoundOn", 1) == 1)
        {
            buttonSound.Play();
        }
        fizik.gravityScale = 3;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void gameOver1()
    {
        gameOverPanel.SetActive(true);
    }

    public void levelHomeButton()
    {
        SceneManager.LoadScene("anaMenu");
    }

    public void levelMenu()
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        
        SceneManager.LoadScene("levelMenu");
    }

    public void levelPass()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

}

