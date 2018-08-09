using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int glowyCount, enemyCount;
    int population, enemies;
    GameObject gHolder, eHolder;
    // Use this for initialization
    void Start()
    {
        glowyCount = 25;
        population = enemies = 0;
        enemyCount = 5;

    }

    // Update is called once per frame
    void Update()
    {
        while (population < glowyCount)
        {
            gHolder = Instantiate(Resources.Load("Prefabs/Glowy")) as GameObject;
            gHolder.transform.position = new Vector3(Random.Range(-180, 180), Random.Range(-90, 90), 0);
            gHolder.AddComponent<GlowyBehaviour>();
            gHolder.name = "Glowy";
            population++;

        }

        while (enemies < enemyCount)
        {
            eHolder = Instantiate(Resources.Load("Prefabs/Enemy")) as GameObject;
            eHolder.transform.position = new Vector3(Random.Range(-180, 180), Random.Range(-90, 90), 0);
            eHolder.AddComponent<EnemyScript>();
            eHolder.name = "Enemy";
            enemies++;
        }

    }
}