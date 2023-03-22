using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameParameters : MonoBehaviour
{
    public TMP_Text distance;
    public TMP_Text coins;
    public TMP_Text speed;

    public float  distanceTraveled;
    public bool isDead;
    
   // private TMP_Text distanceText;
    public GameObject player;

    
    private void Start()
    {
        isDead = false;
        distanceTraveled = 0;
        
    }
    void FixedUpdate() {
        if (!isDead)
        {
            //  distanceTraveled +=(int)(player.GetComponent<MoveAround>().initialSpeed*Time.deltaTime*4);
            distanceTraveled += 0.2f;
            
        }
        distance.text = ((int)distanceTraveled + "m");
        coins.SetText(player.GetComponent<collectCoins>().coinsCollected + "");
        speed.text = ((double)(player.GetComponent<MoveAround>().initialSpeed) + "m/s");
    }

    
}
