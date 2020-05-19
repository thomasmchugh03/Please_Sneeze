using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningLady : BaseEnemy
{

    public GameObject AOE;
    private float nextFire;

    private ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {

        base.OnAwake();

        nextFire = Random.Range(3,6);
        objectPooler = ObjectPooler.Instance;
        moveSpot = Instantiate(moveSpot);
        moveSpot.transform.position = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        base.Patrol();
        DropThatPledge();
    }

    public override void Die()
    {
        Destroy(gameObject);
        Destroy(moveSpot);
    }

    public override void Movement()
    {
        throw new System.NotImplementedException();
    }

    public void DropThatPledge()
    {
        if (Time.time > nextFire)
        {
            objectPooler.SpawnFromPool("LemonPledge", transform.position, Quaternion.identity);
            nextFire = Time.time + Random.Range(3, 6);
        }
    }
}
