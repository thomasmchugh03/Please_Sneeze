using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    public float health;
    public float speed;
    protected GameObject player;

    public float waitTime;
    public GameObject moveSpot;

    public GameObject experiencePrefab;

    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        Movement();
    }

    public virtual void OnAwake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void TakeDamage(float damage)
    {
        if (health - damage <= 0)
        {
            Die();
            for(int i = 0; i < health/10; i++)
            {
                var drop = Instantiate(experiencePrefab, transform.position, Quaternion.identity);

                drop.GetComponent<ExpFollow>().target = player.transform;
            }
        }
        else
        {
            health -= damage;
        }
    }

    public virtual void RunAway()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
    }

    public virtual void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.transform.position, speed * Time.deltaTime);

        if (timeLeft <= 0)
        {
            moveSpot.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
            timeLeft = waitTime;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    public abstract void Movement();

    public abstract void Die();
}
