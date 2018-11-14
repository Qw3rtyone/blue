using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y + 1), 0.05f);

        Object.Destroy(this.gameObject, 3);
	}
}
