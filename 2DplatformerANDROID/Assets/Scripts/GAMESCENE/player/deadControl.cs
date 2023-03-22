using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadControl : MonoBehaviour
{   // detect_death
    public GameObject cam;
    public bool isDead;
    private Rigidbody2D rb;
    //handleDeath
    public int remainingHeart;
    public GameObject game_over_canvas;
    //respawn
    
    public GameObject levelGenerator;
    public bool isActive;
    public Transform parentPart;

    public GameObject bgAudio;
    //
    public GameObject gameScores;
    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();

        remainingHeart = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && transform.position.y < cam.GetComponent<Transform>().Find("deathPosition").transform.position.y)
        {

            isDead=true;
           
           
            if (remainingHeart > 1 && isDead)

            {

                remainingHeart--;
                this.GetComponent<MoveAround>().isDead = true;
                cam.GetComponent<FollowPlayer>().isDead = true;
                this.GetComponent<collectCoins>().isDead = true;
                gameScores.GetComponent<GameParameters>().isDead = true;
                foreach (Transform child in parentPart.transform)
                {
                    Destroy(child.gameObject);
                }
                this.GetComponent<Animator>().SetBool("spawn", true);
                levelGenerator.GetComponent<LevelGenerator>().respawn = true;
               
                cam.GetComponent<FollowPlayer>().isDead = false;
               
                
            }

           else if (remainingHeart == 1 && isDead)
            {
                remainingHeart--;
                this.GetComponent<MoveAround>().isDead = true;
                cam.GetComponent<FollowPlayer>().isDead = true;
                gameScores.GetComponent<GameParameters>().isDead = true;
                this.GetComponent<collectCoins>().isDead = true;
                bgAudio.GetComponent<AudioSource>().Stop();
                game_over_canvas.GetComponent<game_over>().GameOver();
            }
        }
        
    }
}
