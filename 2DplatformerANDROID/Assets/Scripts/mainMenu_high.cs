using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class mainMenu_high : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TMP_Text>().SetText(PlayerPrefs.GetInt("high_score")+"");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
