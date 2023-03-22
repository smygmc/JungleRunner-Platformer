using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnCamMovement : MonoBehaviour
{
    // Start is called before the first frame update
   
    private void Awake()
    {
        Debug.Log("awake");
        this.enabled = false;
    }
    void Start()
    {  
        
        this.GetComponent<FollowPlayer>().enabled = false;
        Debug.Log("start");
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        
    }
}
