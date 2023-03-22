using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartShake : MonoBehaviour
{
    
    private float shake_intensity;
    public Vector3 originPosition1;
    public Vector3 originPosition2;
    public Vector3 originPosition3;

    
    public Transform heart1;
    public Transform heart2;
    public Transform heart3;
    public int remainHeart;




    void Start()
    {
        shake_intensity = 5f;
        remainHeart = 3;
        originPosition1 = heart1.position;
        originPosition2 = heart2.position;
        originPosition3 = heart3.position;



    }

    void Update()
    {
        // remainHeart = this.GetComponent<HandleDeath>().remainingHeart;
        remainHeart = this.GetComponent<deadControl>().remainingHeart;
        if (remainHeart == 3)
        {
            heart1.position = originPosition1 + Random.insideUnitSphere * shake_intensity;
            heart2.position = originPosition2 + Random.insideUnitSphere * shake_intensity;
            heart3.position = originPosition3 + Random.insideUnitSphere * shake_intensity;
        }
       else if (remainHeart == 2)
        {
            heart1.position = originPosition1 + Random.insideUnitSphere * shake_intensity;
            heart2.position = originPosition2 + Random.insideUnitSphere * shake_intensity;
            heart3.GetComponent<Animator>().SetBool("loss", true);
        }
        else if (remainHeart == 1)
        {
            heart1.position = originPosition1 + Random.insideUnitSphere * shake_intensity;
            heart2.GetComponent<Animator>().SetBool("loss", true);
        }
        else {
            heart1.GetComponent<Animator>().SetBool("loss", true);
        }



    }
}
