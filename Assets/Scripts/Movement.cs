using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {
    public int speed;
    Vector3 pos;
    Rigidbody2D player;
	// Use this for initialization
	void Start () {
        speed = 2;
        player = this.GetComponent<Rigidbody2D>();
        
    }
	
    private void Move(Vector3 target)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target, Time.deltaTime * speed);
        
        //this.transform.position = temp;
        

    }

    private Vector3 ClampPos(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -200, 200);
        pos.y = Mathf.Clamp(pos.y, -100, 100);
        
        return pos;
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
        pos = ClampPos(pos);
        Move(pos);
        //Debug.Log("Pos = " + pos);
        

    }
}
