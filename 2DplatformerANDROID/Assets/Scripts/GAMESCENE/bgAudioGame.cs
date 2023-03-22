using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgAudioGame : MonoBehaviour
{
    GameObject menuBgAudio;
    void Start()
    {
        GetComponent<AudioSource>().volume = 0;
        menuBgAudio = GameObject.Find("menuBgAudio");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("music")!=0) {
            while (GetComponent<AudioSource>().volume <= 0.4f)
            {
                GetComponent<AudioSource>().volume += 0.01f;
            }

        if (menuBgAudio!=null && menuBgAudio.GetComponent<AudioSource>().volume ==0) {
                 Destroy(menuBgAudio); 
            }
        }
    }
}
