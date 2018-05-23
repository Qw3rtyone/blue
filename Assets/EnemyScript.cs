using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    Transform myTransform, target;
    int moveSpeed;
    float rotationSpeed = 5;
    // Use this for initialization
    void Start()
    {
        moveSpeed = 5;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        //move towards the player
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }
}
