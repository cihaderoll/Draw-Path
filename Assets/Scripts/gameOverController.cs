using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverController : MonoBehaviour
{
    public Text scoreText;
    private int displayScore = 0;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    

    void levelPass()
    {
        oyunKontrol.instantiate.levelPassPanel.SetActive(true);
    }

    void levelFail()
    {
        oyunKontrol.instantiate.gameOverPanel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ball" )
        {
            if (oyunKontrol.instantiate.starCollected)
            {
                oyunKontrol.instantiate.score = (int)(oyunKontrol.instantiate.slider.value * 1000 + oyunKontrol.instantiate.levelCount * 100);
                for (int i = 1; i <= 10; i++)
                {
                    if (oyunKontrol.instantiate.levelCount == i)
                    {
                        if (PlayerPrefs.GetInt("levelScoreKayit" + i, 0) < oyunKontrol.instantiate.score)
                        {
                            PlayerPrefs.SetInt("levelScoreKayit" + i, oyunKontrol.instantiate.score);
                        }
                    }
                }

                oyunKontrol.instantiate.isFree = false;
                oyunKontrol.instantiate.fizik.gravityScale = 0;
                Invoke("freeze", 0.5f);
                Invoke("levelPass", 0.5f);
                Invoke("scoreCount", 1f);
                PlayerPrefs.SetInt("levelKayit", oyunKontrol.instantiate.levelCount + 1);
            }
            else
            {
                Invoke("levelFail", 0.5f);
            }
            
        }
    }

    private void freeze()
    {
        oyunKontrol.instantiate.fizik.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void scoreCount()
    {
        StartCoroutine(scoreUpdater());
    }

    private IEnumerator scoreUpdater()
    {
        while (true)
        {
            if(displayScore < oyunKontrol.instantiate.score)
            {
                
                displayScore += 23 * oyunKontrol.instantiate.levelCount;
                if(displayScore > oyunKontrol.instantiate.score)
                {
                    displayScore = oyunKontrol.instantiate.score;
                }
                scoreText.text = displayScore.ToString();

            }

            yield return new WaitForSeconds(0.001f);
        }
    }


}
