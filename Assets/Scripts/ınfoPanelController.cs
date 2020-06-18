using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ınfoPanelController : MonoBehaviour
{

    public GameObject ınfoPanel;
    int i = 0;
    
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if(PlayerPrefs.GetInt("ınfoPanelKontrol", 0) == 0)
        {
            ınfoPanel.SetActive(true);
            
        }
        PlayerPrefs.SetInt("ınfoPanelKontrol", 1);
        Invoke("closePanel", 2.5f);
    }

    public void closePanel()
    {
        ınfoPanel.SetActive(false);
    }

    void Update()
    {
        
    }
    
    
}
