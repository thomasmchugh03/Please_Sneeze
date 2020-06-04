using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement target;
    public Vector2 offset;
    public float speed = 3f;
    private Vector2 threshold;


    void Start()
    {
        threshold = calculateThreshold();

    }

    void FixedUpdate()
    {
        Vector2 follow = target.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPosition = transform.position;
        if(Math.Abs(xDifference) >= threshold.x)
        {
            newPosition.x = follow.x;
        }
        if (Math.Abs(yDifference) >= threshold.y)
        {
            newPosition.y = follow.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, newPosition, target.getSpeed() * Time.fixedDeltaTime);
    }

    private Vector3 calculateThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);

        t.x -= offset.x;
        t.y -= offset.y;
        return t;
    }

    private void OnDrawGizmo()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
