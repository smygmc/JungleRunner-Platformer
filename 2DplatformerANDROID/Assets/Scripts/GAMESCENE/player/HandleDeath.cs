using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    public bool isDead;
    public int remainingHeart;
    public GameObject game_over_canvas;
    public GameObject cam;
  
    void Start()
    {
        isDead = false;
        remainingHeart = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        
            
            if (remainingHeart > 1 && isDead)

            {  
            
                remainingHeart--;
                this.GetComponent<respawn>().isActive = true;
                isDead = false;
            Debug.Log("kalan can " + remainingHeart);
            }

           if (remainingHeart == 1 && isDead)
            {
                 game_over_canvas.GetComponent<game_over>().GameOver();
            }
        
        
    }
}
