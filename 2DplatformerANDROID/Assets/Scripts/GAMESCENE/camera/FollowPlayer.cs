using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Vector3 offset;
    public float initialSpeed;
    private float playerSpeed;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {

        this.enabled = false;
        isDead = false;
        playerSpeed = player.GetComponent<MoveAround>().initialSpeed;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            playerSpeed = player.GetComponent<MoveAround>().initialSpeed;
            initialSpeed = playerSpeed;//-1 koyabilirim //koymayabilirim çok öne gidiyo oyuncu
            Vector3 desiredPos = player.position + offset;

            if (player.position.x >= transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + ((initialSpeed + 4f) * Time.fixedDeltaTime),
                    Mathf.Lerp(transform.position.y, desiredPos.y, speed * Time.fixedDeltaTime), -30f);


            }
            else
            {
                transform.position = new Vector3(transform.position.x + (initialSpeed * Time.fixedDeltaTime), Mathf.Lerp(transform.position.y, desiredPos.y, speed * Time.fixedDeltaTime), -30f);
            }
        }
        if (isDead)
        {

        }
    }
}
