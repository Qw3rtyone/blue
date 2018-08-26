using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    Transform myTransform;
    GameObject player;
    Vector2 target;
    public float moveSpeed, bonus;

    // Use this for initialization
    void Start()
    {
        moveSpeed = Random.Range(5,8);
        bonus = 0.1f;
        player = GameObject.FindGameObjectWithTag("Player");
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            target = player.transform.position;
            if (Vector2.Distance(target, transform.position) < 10 && bonus >= 0)
                bonus += 0.1f;
            else if (bonus > 0.0)
                bonus -= 0.5f;
            if (bonus < 0)
                bonus = 0;
            myTransform.position = Vector2.MoveTowards(myTransform.position, target, (moveSpeed + bonus) * Time.deltaTime);
        }

    }
}
