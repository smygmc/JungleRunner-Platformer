using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGameOver : MonoBehaviour
{
    public GameObject player;
   
    void Start()
    {
        this.enabled = false;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        
            transform.position = new Vector3(player.transform.position.x+20f, Mathf.Lerp(transform.position.y, player.transform.position.y, 0.5f * Time.fixedDeltaTime), transform.position.z);
        
    }
}
