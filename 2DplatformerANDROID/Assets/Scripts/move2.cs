using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    public float initialSpeed;
    Rigidbody2D rb;
    public int a;
    void Start()
    {
        a = 5;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        initialSpeed = a * Time.fixedDeltaTime;  
    }
}
