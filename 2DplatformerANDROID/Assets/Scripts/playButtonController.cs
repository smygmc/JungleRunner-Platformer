using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButtonController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject image;
    private Animator anim;

    public GameObject bgAudio;
    private void Awake()
    {
        this.enabled = false;
    }
    void Start()
    {
        StartCoroutine(waitTwoSeconds());
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        bgAudio.GetComponent<bgAudio>().load = true;
        canvas.gameObject.SetActive(false);
        anim.SetBool("buttonDown", true);
        image.GetComponent<Animator>().SetBool("fade", true);
        canvas.GetComponent<Animator>().SetBool("canvasScale", true);

      
    }

    IEnumerator waitTwoSeconds()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("game");
        Debug.Log("sahne yuklendý");

    }
}
