using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoins : MonoBehaviour
{
    public int coinsCollected;
    public int totalScore;
    public int speedScore;
    public bool isDead;
    public GameObject game_scores;
    private float distanceTraveled;
    public GameObject coinSource;

    void Start()
    {
        coinsCollected = 0;
        speedScore = 0;
        totalScore = 0;
        isDead = false;
        
    }

    
    void Update()
    {
        distanceTraveled = game_scores.GetComponent<GameParameters>().distanceTraveled;
        if (!isDead)
        {
            //speedScore += (int)(this.GetComponent<MoveAround>().initialSpeed/Time.deltaTime);
            totalScore = (int)(coinsCollected * 50+distanceTraveled); //BU HESAPLAMA KONUSUNDA KAFAM KARIÞIK HALA
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            if (PlayerPrefs.GetInt("sound") != 0) { coinSource.GetComponent<AudioSource>().Stop(); }
            coinsCollected++;
            if (PlayerPrefs.GetInt("sound") != 0) { coinSource.GetComponent<AudioSource>().Play(); }
            Destroy(collision.gameObject);
        }
    }
}
