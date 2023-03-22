using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgAudio : MonoBehaviour
{
    int isActive;
    public bool load;
    float defaultVolume;
    void Start()
    {
        defaultVolume = 1f;
        isActive = PlayerPrefs.GetInt("music");
        if (isActive == 1)
        {
           

            load = false;
            DontDestroyOnLoad(this.gameObject);
        }
        if (isActive == 0)
        {
            GetComponent<AudioSource>().volume = 0;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isActive = PlayerPrefs.GetInt("music");
        if (isActive == 1)
        {
            if (!load) { GetComponent<AudioSource>().volume = defaultVolume; }
            if (load)
            {
                load = true;
                GetComponent<AudioSource>().volume -=0.005f;
            }
        }
        if (isActive == 0)
        {
            GetComponent<AudioSource>().volume = 0;

        }


    } 
}
