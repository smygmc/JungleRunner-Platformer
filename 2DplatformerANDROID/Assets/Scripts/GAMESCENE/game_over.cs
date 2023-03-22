using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{ // child2 high score
    //child3 current score
    public GameObject cam;
    public GameObject player;
   
    public Canvas gameControl;
    
    private int highScore;
    public GameObject gameOverAudio;
  
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        
        
        highScore = PlayerPrefs.GetInt("high_score");
    }

    
    public void GameOver()
    {
            
            StartCoroutine(waitThreeSeconds());

            if (PlayerPrefs.GetInt("sound") != 0) { gameOverAudio.GetComponent<AudioSource>().Play(); }
            this.GetComponent<Transform>().GetChild(0).GetComponent<Animator>().SetBool("fade", true);
            gameControl.GetComponent<Canvas>().enabled = false;
            GetComponent<Canvas>().enabled = true;
            cam.GetComponent<FollowPlayer>().enabled = false;
            cam.GetComponent<CamGameOver>().enabled = true;
            if (player.GetComponent<collectCoins>().totalScore > highScore)
            {
                PlayerPrefs.SetInt("high_score", player.GetComponent<collectCoins>().totalScore);
                this.GetComponent<Transform>().GetChild(4).gameObject.GetComponent<TMP_Text>().SetText("NEW HIGH SCORE \n" + PlayerPrefs.GetInt("high_score"));
                
            }
            else
            {
                this.GetComponent<Transform>().GetChild(3).gameObject.GetComponent<TMP_Text>().SetText("YOU DID " + player.GetComponent<collectCoins>().totalScore);
                this.GetComponent<Transform>().GetChild(2).gameObject.GetComponent<TMP_Text>().SetText("HIGH SCORE " + PlayerPrefs.GetInt("high_score"));
            }
        
    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("MainMenu");
    }
    }
