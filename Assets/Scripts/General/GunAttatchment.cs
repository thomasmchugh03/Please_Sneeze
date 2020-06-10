using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttatchment : MonoBehaviour
{
    public Rigidbody2D mainbody;
    public float speed;
    public Camera cam;

    private Transform target;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        //Find the target that you want the object to move towards
        target = GameObject.FindGameObjectWithTag("FirePoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (target == null)
        {
            //Do nothing
        }

        //If the distance between the object and the target is greater than 0, have the object move towards the target
        else if (Vector2.Distance(transform.position, target.position) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        //Subtracting two vectors results in a vector that points from one to the other
        Debug.Log(cam.transform.position);
        Vector2 lookDir = mousePos - mainbody.position;

        //For the Z rotation of the object, we need to find the angle that will force the player to turn and change the initial firing position
        //will be visualized later in animation if we choose to
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        mainbody.rotation = angle;

    }


}
