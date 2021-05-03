using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkTo : MonoBehaviour
{

    public Transform[] spawnPos;
    public GameObject[] monsters;
    int randomSpawnpoint, randomMonster;


    void Start()
    {
        InvokeRepeating("spawnMonster", 0f, 3.0f);
    }

    void spawnMonster()
    {
        randomSpawnpoint = Random.Range(0, spawnPos.Length);
        randomMonster = Random.Range(0, monsters.Length);
        Instantiate(monsters[randomMonster], spawnPos[randomSpawnpoint]);
    }
}

