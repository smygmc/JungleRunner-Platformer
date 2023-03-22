using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOpening : MonoBehaviour
{
    public GameObject player;
    public GameObject gameControl;
    public GameObject cam;

    void Start()
    {
        StartCoroutine(waitTwoSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitTwoSeconds()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        player.GetComponent<MoveAround>().enabled = true;
        cam.GetComponent<FollowPlayer>().enabled = true;
        // cam.GetComponentInChildren<MoveBackground>().enabled = true;
        for (int i = 0; i < 5; i++)
        {
            cam.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Transform>().GetChild(i).GetComponent<MoveBackground>().enabled = true;
        }
        cam.GetComponent<Animator>().enabled = false;
        gameControl.SetActive(true);
        this.enabled = false;
    }
}
