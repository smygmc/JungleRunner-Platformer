using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_death : MonoBehaviour
{   
    public GameObject cam;
    public bool isDead;
    private Rigidbody2D rb;
   
    void Start()
    {
        isDead = false;
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (!isDead && transform.position.y < cam.GetComponent<Transform>().Find("deathPosition").transform.position.y)
            {
           
           
                this.GetComponent<HandleDeath>().isDead = true;
                this.GetComponent<MoveAround>().isDead = true;
                cam.GetComponent<FollowPlayer>().isDead = true;
                isDead = true;
                
           
            }
        
    }
}
