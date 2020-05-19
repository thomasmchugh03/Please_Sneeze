using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBullet : MonoBehaviour, iPooledObject
{
    public float speed;
    public Rigidbody2D rb;
    public float damage;

    private GameObject target;
    private Vector2 moveDirection;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            Debug.Log("Hit");
            player.TakeDamage(damage);
        }
    }

}
