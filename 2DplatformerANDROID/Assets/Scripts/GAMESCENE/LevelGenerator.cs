using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART=50F;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform levelPart_start;
    private Vector3 lastEndPosition;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform parentPart;
    [SerializeField] private Transform coin_enemy_gen;
    private List<Transform> lastLevelPartCoinPositions;
    public GameObject player;
    public float playerSpeed;
    public bool respawn;
    public Transform spawnPoint;
    private float initialPlayerSpeed;
    private float ek;

    public GameObject coin;
    float coin_width;
    float coin_height;


    private void Awake()
    {
        respawn = false;
        initialPlayerSpeed = 22;

        lastEndPosition = levelPart_start.Find("EndPosition").position;


        coin_width = coin.GetComponent<Renderer>().bounds.size.x;
        coin_height = coin.GetComponent<Renderer>().bounds.size.y;


    }

    private void FixedUpdate()
    {
        if (respawn)
        {

            lastEndPosition=SpawnLevelPart(spawnPoint, cam.Find("EndPosition").position).Find("EndPosition").position; 
            player.transform.position = new Vector3(parentPart.GetChild(0).Find("spawnPos").transform.position.x, parentPart.GetChild(0).Find("spawnPos").transform.position.y+2, 0);

            respawn = false;
        }

       if(!respawn)
        {
            playerSpeed = player.GetComponent<MoveAround>().initialSpeed;

            ek = (playerSpeed) * 1.51f;

            if (Vector3.Distance(cam.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
            {
                SpawnLevelPart();

            }
            if (parentPart.GetComponent<Transform>().childCount != 0) { 
            if (Vector3.Distance(cam.position, (parentPart.GetComponent<Transform>().GetChild(0).gameObject).transform.position) > 150f)

            {
                Destroy(parentPart.GetComponent<Transform>().GetChild(0).gameObject);
            }
        }
        }
   
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[UnityEngine.Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform=SpawnLevelPart(chosenLevelPart,lastEndPosition+ new Vector3(ek, 0, 0));
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
       
        
    }
    private Transform SpawnLevelPart(Transform levelPart,Vector3 spawnPosition)
    {
       
       Transform levelPartTransform=Instantiate(levelPart, spawnPosition, Quaternion.identity,parentPart);
        if (!respawn)
        {
            SpawnCoin(levelPartTransform, spawnPosition);
        }
        return levelPartTransform;
        
    }
    
    private void SpawnCoin(Transform LevelPart,Vector3 spawnPosition) {
        int decide= UnityEngine.Random.Range(0,2);
        if (decide == 1)
        {
            GameObject platform = LevelPart.Find("platform").gameObject;
            float width = platform.GetComponent<Renderer>().bounds.size.x;
            float height = platform.GetComponent<Renderer>().bounds.size.y;
           
            int gap = 2;
            int howMany =(int)((width)/(coin_width+gap)); // platforma kaç coin sýðar?
           
            float margin = width - (howMany*(coin_width+gap)); // ne kadar boþluk kalýr?
            
            
            
            

           
          


            for (int i = 0; i <= (int)howMany; i++)
            {
                Vector3 coinPos= new Vector3(platform.transform.position.x - (width / 2) + (margin / 2) + (i * (coin_width + gap)), platform.transform.position.y + (height / 2) + (coin_height / 2), 0);
               
                Instantiate(coin, coinPos, Quaternion.identity, parentPart);
            }
        }
    }


}

