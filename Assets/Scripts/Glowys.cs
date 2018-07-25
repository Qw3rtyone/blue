using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowys : MonoBehaviour
{

    public int glowyCount;
    int population;
    GameObject gHolder;
    // Use this for initialization
    void Start()
    {
        glowyCount = 10;
        population = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while (population < glowyCount)
        {
            gHolder = Instantiate(Resources.Load("Prefabs/Glowy")) as GameObject;
            gHolder.transform.position = new Vector3(Random.Range(-180, 180), Random.Range(-90, 90), 0);
            gHolder.AddComponent<GlowyBehaviour>();

            population++;

        }

    }
}