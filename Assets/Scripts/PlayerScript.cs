using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Movement player;
	// Use this for initialization
	void Start () {
        player = Camera.main.GetComponent<Movement>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.Collision(collision);
        Debug.Log("Hit!");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
