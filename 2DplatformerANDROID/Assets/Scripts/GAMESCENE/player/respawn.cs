using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject cam;
    public GameObject levelGenerator;
    public bool isActive;
    public Transform parentPart;
    
  
    public float camInitialSpeed;

    void Start()
    {
       isActive = false;

    }
    public void FixedUpdate()
    {
        if (isActive)
        {
            
            foreach(Transform child in parentPart.transform)
            {
                Destroy(child.gameObject);
            }
            levelGenerator.GetComponent<LevelGenerator>().respawn = true;
           // this.transform.position = new Vector3(parentPart.GetChild(0).Find("spawnPos").transform.position.x, parentPart.GetChild(0).Find("spawnPos").transform.position.y+3, 0);
            cam.GetComponent<FollowPlayer>().isDead = false;

            isActive = false;
            
        }

    }
    // Update is called once per frame
    public void RespawnPosition()
    {

    }
}
