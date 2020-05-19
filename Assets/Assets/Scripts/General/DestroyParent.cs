using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{

    public float exp;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        PlayerExp player = hitInfo.GetComponent<PlayerExp>();

        if (player != null)
        {
            Destroy(transform.parent.gameObject);
            player.addEXP(exp);
        }
    }
}
