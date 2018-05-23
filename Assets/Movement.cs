﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {
    int speed;
    Vector3 pos;
    Rigidbody2D player;
	// Use this for initialization
	void Start () {
        speed = 10;
        player = this.GetComponent<Rigidbody2D>();
	}
	
    private void Move(Vector3 target)
    {
        Vector3 temp = Vector3.Lerp(this.transform.position, target, Time.deltaTime * 5.0f);
        this.transform.position = temp;
        

    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                pos = hit.point;
            }
        }
        Move(pos);
        Debug.Log("Pos = " + pos);
	}
}