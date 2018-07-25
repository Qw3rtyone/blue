using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowyBehaviour : MonoBehaviour
{

    public int rotateSpeed;
    // Use this for initialization
    void Start()
    {
        rotateSpeed = 180;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }
}
