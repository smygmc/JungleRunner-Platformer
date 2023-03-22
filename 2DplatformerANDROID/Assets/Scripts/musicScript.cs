using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    public GameObject music_off;

    int music;
    void Start()
    {

        music = PlayerPrefs.GetInt("music");
        

        if (music == 1)
        {
            music_off.SetActive(false);
        }
        if (music == 0)
        {
            music_off.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        music = PlayerPrefs.GetInt("music");


    }

    public void OnClick()
    {

        if (music == 1)// müzik kapalý
        {

            PlayerPrefs.SetInt("music", 0); // aç
            music_off.SetActive(true);
        }
        else if (music == 0)
        {
            PlayerPrefs.SetInt("music", 1);
            music_off.SetActive(false);
        }
    }
}
