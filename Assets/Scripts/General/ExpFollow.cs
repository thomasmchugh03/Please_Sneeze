using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpFollow : MonoBehaviour
{
    public Transform target;
    public float minModifier;
    public float maxModifier;
    public Rigidbody2D rb;
    public float force;

    Vector3 velocity = Vector3.zero;
    bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector2(Random.Range(-force, force), Random.Range(-force, force)));
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (isFollowing && target != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, Time.deltaTime * Random.Range(minModifier, maxModifier));
        }
    }
}
