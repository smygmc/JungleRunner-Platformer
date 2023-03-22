using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundScript : MonoBehaviour
{
    public GameObject sound_on;
   
    int is_on;
    void Start()
    {
       
        is_on = PlayerPrefs.GetInt("sound");
        

        if (is_on == 0)
        {
            sound_on.SetActive(false);
        }
        if (is_on == 1)
        {
            sound_on.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        is_on= PlayerPrefs.GetInt("sound");


    }

    public void OnClick()
    {
        
        if (is_on == 0)
        {
            
            PlayerPrefs.SetInt("sound", 1);
            sound_on.SetActive(true);
        } 
        else if (is_on == 1)
        {
            PlayerPrefs.SetInt("sound", 0);
            sound_on.SetActive(false);
        }
    }
}
