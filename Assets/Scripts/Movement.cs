using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Movement : MonoBehaviour {
    public int speed;
    Vector3 pos, OFFSET = new Vector3(0, 0, 30);
    Rigidbody2D player;
    public GameObject ShieldScore, Player, Points;
    public Spawner Spawner;
    public GameObject[] gameOver;
    int points,safeGuard;
	// Use this for initialization
	void Start () {
        points = 0;
        speed = 2;
        Player = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
        player = Player.GetComponent<Rigidbody2D>();
        Player.transform.position = this.transform.position + OFFSET;
        ShieldScore = GameObject.FindGameObjectWithTag("ShieldScore");
        Spawner = GameObject.FindGameObjectWithTag("Quad").GetComponent<Spawner>();
        Points = GameObject.FindGameObjectWithTag("Points");
        GameStart();
       
        Time.timeScale = 1f;
    }
	
    private void Move(Vector3 target)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target, Time.deltaTime * speed);
        if(Player != null)
            Player.transform.position = this.transform.position + OFFSET;
        //this.transform.position = temp;
        

    }
    public void Collision(Collision2D collision)
    {
        if (collision.gameObject.name == "Glowy")
        {
            Collect();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Enemy")
        {
            RemoveGuard(collision.gameObject);
            if (safeGuard < 0 && gameOver.Length > 0)
            {
                GameOver();

                GameObject go = Instantiate(Resources.Load("Prefabs/Dead")) as GameObject;
                go.transform.position = Player.gameObject.transform.position;

                Destroy(Player);
                Debug.Log("Stop! You Died!");
            }
        }
    }
    private void Collect()
    {
        safeGuard += 1;
        ShieldScore.GetComponent<Text>().text = safeGuard.ToString();
        Debug.Log("Safe = " + safeGuard);
    }
    private void RemoveGuard(GameObject gameObject)
    {
        Spawner.enemies--;
        safeGuard--;
        points += 10;

        Destroy(gameObject);

        ShieldScore.GetComponent<Text>().text = safeGuard.ToString();
        Points.GetComponent<Text>().text = points.ToString();
        
        //The explosion effect
        GameObject ex = Instantiate(Resources.Load("Prefabs/Dead")) as GameObject;
        ex.transform.position = Player.gameObject.transform.position;

        FloatingPoints();

        
        //Debug.Log("Safe = " + safeGuard);
    }
    
    private void FloatingPoints()
    {
        //The floating score (Possible bonus points for quick kills)
        GameObject po = Instantiate(Resources.Load("Prefabs/KillPoints")) as GameObject;
        po.GetComponent<TextMesh>().text = "10";
        po.GetComponent<TextMesh>().characterSize = 1;
        po.AddComponent<Suicide>();
        po.transform.position = Player.gameObject.transform.position;

    }
    private Vector3 ClampPos(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -200, 200);
        pos.y = Mathf.Clamp(pos.y, -100, 100);
        pos.z = -30;
        return pos;
    }
    private void GameStart()
    {
        Time.timeScale = 1.0f;
        // deactivate gameover overlay after setting time to normal
        foreach (GameObject gameover in gameOver)
        {
            gameover.SetActive(false);
        }
        //set initial points to 0 at start of game
        Points.GetComponent<Text>().text = points.ToString();
        
    }
    private void GameOver()
    {
        foreach (GameObject gameover in gameOver)
        {
            Time.timeScale = 0.05f;
            gameover.SetActive(true);
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
