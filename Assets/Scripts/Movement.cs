using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Movement : MonoBehaviour {
    public int speed;
    Vector3 pos;
    Rigidbody2D player;
    public GameObject Score, gameOver;
    int points,safeGuard;
	// Use this for initialization
	void Start () {
        points = 0;
        speed = 2;
        player = this.GetComponent<Rigidbody2D>();
        Score = GameObject.FindGameObjectWithTag("Score");
        gameOver.SetActive(false);
        Time.timeScale = 1f;
    }
	
    private void Move(Vector3 target)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target, Time.deltaTime * speed);
        
        //this.transform.position = temp;
        

    }
    private void Collect()
    {
        safeGuard += 1;
        Score.GetComponent<Text>().text = safeGuard.ToString();
        Debug.Log("Safe = " + safeGuard);
    }
    private void RemoveGuard()
    {
        safeGuard--;

        Score.GetComponent<Text>().text = safeGuard.ToString();
        Debug.Log("Safe = " + safeGuard);
    }
    private Vector3 ClampPos(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -200, 200);
        pos.y = Mathf.Clamp(pos.y, -100, 100);
        
        return pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Glowy")
        {
            Collect();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Enemy")
        {
            RemoveGuard();
            if(safeGuard < 0)
            {
                Time.timeScale = 0f;
                gameOver.SetActive(true);
                Destroy(collision.gameObject);
                Debug.Log("Stop! You Died!");
            }
        }
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
