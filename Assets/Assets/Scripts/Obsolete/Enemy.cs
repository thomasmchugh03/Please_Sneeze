using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;

    public float speed;
    public float patrollingDistance;
    public float retreatingDistance;
    public float waitTime;
    public GameObject moveSpot;

    private GameObject player;
    private float timeLeft;
    

    // Start is called before the first frame update
    void Start()
    {
        moveSpot = Instantiate(moveSpot);

        player = GameObject.FindGameObjectWithTag("Player");

        timeLeft = waitTime;
        moveSpot.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    public void TakeDamage(float damage)
    {
        if(health - damage < 0)
        {
            Destroy(gameObject);
            Destroy(moveSpot);
        }
        else
        {
            health -= damage;
        }
    }

    private void Movement()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < retreatingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.transform.position) > patrollingDistance)
        {
            Patrol();
        }

    }

    private void Patrol() 
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.transform.position, speed * Time.deltaTime);
        
        if(timeLeft <= 0)
        {
            moveSpot.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            timeLeft = waitTime;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
        
    }



}
