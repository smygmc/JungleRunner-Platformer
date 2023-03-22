using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform cam;
    public float speed;
    private Renderer rnd;

    // Update is called once per frame

    private void Start()
    {
        this.enabled = false;
        rnd= GetComponent<Renderer>();
    }
    void Update()
    {
        speed = (cam.GetComponent<FollowPlayer>().initialSpeed * this.rnd.sortingOrder)/10;
        transform.position = new Vector3(transform.position.x + (-1 * speed * Time.fixedDeltaTime), transform.position.y, transform.position.z);

        if (cam.position.x >= transform.position.x + 73.89692f)// gruplandýrdýktan sonraki ayný cinslerin arasýndaki fark
        {
            transform.position = new Vector3(transform.position.x+ 74.0241f, transform.position.y, transform.position.z);
        }
        
    }
}
