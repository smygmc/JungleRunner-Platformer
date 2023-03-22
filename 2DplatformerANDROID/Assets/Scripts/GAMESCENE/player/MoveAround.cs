using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAround : MonoBehaviour // movement,animation
{
    public bool isDead;
    Rigidbody2D rb;
    public GameObject cam;
    public float initialSpeed;
   
    bool isGrounded;
    bool canJump;
    private Animator anim;

    int MAX_SPEED = 32;
    float speedCoefficient;

    public GameObject gameScores;
    public GameObject jumpAudio;

    float jumpRememberTimer;
    float groundRememberTimer;
    

    // Start is called before the first frame update
    void Start()

        
    {   
        this.enabled = false;
        jumpRememberTimer = 0;
        groundRememberTimer = 0;
         rb = GetComponent<Rigidbody2D>();
         anim = GetComponent<Animator>();
        speedCoefficient = 0;
        isDead = false;
        
    }

    // Update is called once per frame
    void Update()

        
    {
        
        if (!isDead)
        {
            jumpRememberTimer -= Time.deltaTime;
            groundRememberTimer -= Time.deltaTime;
            anim.SetBool("spawn", false);
            //this.GetComponent<detect_death>().enabled = true;
            //this.GetComponent<detect_death>().isDead = false;
            this.GetComponent<deadControl>().isDead = false;
            gameScores.GetComponent<GameParameters>().isDead = false;
            this.GetComponent<collectCoins>().isDead = false;

            if (isGrounded)
            {

                //end = transform.position.x;
                //Debug.Log("start"+start);
                //Debug.Log("end"+end);
                //Debug.Log(end - start);
                anim.SetBool("isLanded", true);
                anim.SetBool("isFalling", false);
                anim.SetBool("isRunning", true);

            }


            if (jumpRememberTimer>0 && groundRememberTimer>0)
            {
                jumpRememberTimer = 0;
                groundRememberTimer = 0;
                if (PlayerPrefs.GetInt("sound") != 0) { jumpAudio.GetComponent<AudioSource>().Play(); }
                anim.SetBool("isLanded", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", true);

                rb.velocity = new Vector3(0, 45, 0f);


                canJump = false;
                isGrounded = false;



            }
            //bi engele takýlýnca yatay atýþ yapsýn diye yoksa takýlýp kalýr orda
            
            if (rb.velocity.y < 0)
            {   
                isGrounded = false;
                anim.SetBool("isLanded", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", true);

            }

        }

        if (isDead)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            jumpRememberTimer = 0;
            groundRememberTimer = 0;


        }
        if (isDead && this.GetComponent<deadControl>().remainingHeart == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            jumpRememberTimer = 0;
            groundRememberTimer = 0;


        }



    }

    private void FixedUpdate()
    {
        if (!isDead)
        {

            transform.position = new Vector3(transform.position.x + ((initialSpeed) * Time.fixedDeltaTime), transform.position.y, transform.position.z);
            if (initialSpeed < MAX_SPEED)
            {
                speedCoefficient += 0.000003f;
                initialSpeed = initialSpeed + speedCoefficient;
            }
        }
        if (isDead)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            jumpRememberTimer = 0;
            groundRememberTimer = 0;


            if (transform.position.x < cam.GetComponent<Transform>().Find("spawnPos").transform.position.x)
            {
                
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                

                isDead = false;
                
            }
        }
        if (isDead && this.GetComponent<deadControl>().remainingHeart == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;



        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && collision.transform.position.y < transform.position.y) // could also be replaced with collision.gameObject.tag
        {
            groundRememberTimer = 0.2f;
            isGrounded = true;
            anim.SetBool("isLanded", true);
        }
        else if(collision.gameObject.tag == "ground" && collision.transform.position.y >= transform.position.y)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else { }
        

    }
    


    public void jump()
    {
        jumpRememberTimer = 0.2f;
        canJump = true; // canJump==jumpPressed
       
    }
    public void noJump()
    {
        canJump=false; 
    }


    
}