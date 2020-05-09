using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float move;

    public Rigidbody2D mainbody;
    public Animator animator;
    public GameObject dashEffect;

    Vector2 movement;

    void Start()
    {
        mainbody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        move = moveSpeed;
    }

    void Update()
    {
        //Dashing is called as a coroutine because of inconsistency with Time.deltaTime making dashtime never get assigned consistently to startDashTime
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetFloat("Speed") > 0)
        {
            StartCoroutine("Dashing");
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        //Movement
        //Time.fixedDeltaTime is there because it results in consistent movement speed in game, as to how I am uncertain
        mainbody.MovePosition(mainbody.position + movement * move * Time.fixedDeltaTime);

    }

    IEnumerator Dashing()
    {

        //Creat dash animation, then destroy it to not take up resources
        GameObject cloud = Instantiate(dashEffect, transform.position, Quaternion.identity);

        //Assign speed to dashspeed, wait the alloted time, then return to normal
        move = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        move = moveSpeed;
        Destroy(cloud, .5f);

    }
}
