using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> coin_enemy_list;
   
    public void GenerateCoin(List<Transform> spawnPositions)
    {
        for (int i = 0; i< spawnPositions.Count; i++) {
            Instantiate(coin_enemy_list[0], spawnPositions[i].position, Quaternion.identity); }
    }
}
