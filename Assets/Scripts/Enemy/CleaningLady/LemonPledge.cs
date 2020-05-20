using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonPledge : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
