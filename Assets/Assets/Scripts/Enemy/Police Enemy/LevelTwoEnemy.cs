using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoEnemy : BaseEnemy
{

    public float patrollingDistance;
    public float retreatingDistance;
    public GameObject bullet;

    public float fireRate;
    private float nextFire;

    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        base.OnAwake();
        nextFire = Time.fixedDeltaTime;
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            
            GameObject firedBullet = objectPooler.SpawnFromPool("PoliceBullet", transform.position, Quaternion.identity); 
            nextFire = Time.time + fireRate;
            
        }
        
    }

    public override void Movement()
    {
        if(player == null)
        {

        }
        else if (Vector2.Distance(transform.position, player.transform.position) < retreatingDistance - .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.fixedDeltaTime);
            Shoot();
        }
        else if (Vector2.Distance(transform.position, player.transform.position) > retreatingDistance + .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
        else
        {
            Shoot();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
  
    }

}
