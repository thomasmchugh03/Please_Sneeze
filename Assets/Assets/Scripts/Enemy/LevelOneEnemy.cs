using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneEnemy : BaseEnemy
{

    public float patrollingDistance;
    public float retreatingDistance;

    // Start is called before the first frame update
    void Start()
    {

        base.OnAwake();

        moveSpot = Instantiate(moveSpot);

        moveSpot.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Movement();
    }

    public override void Die()
    {
        Destroy(gameObject);
        Destroy(moveSpot);
    }

    public override void Movement()
    {
        if(player == null)
        {

        }
        else if (Vector2.Distance(transform.position, player.transform.position) < retreatingDistance)
        {
            base.RunAway();
        }
        else if (Vector2.Distance(transform.position, player.transform.position) > patrollingDistance)
        {
            base.Patrol();
        }
    }

}
