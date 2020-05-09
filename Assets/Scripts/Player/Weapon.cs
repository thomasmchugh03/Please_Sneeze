using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject coneColliderPrefab;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
        
    }


    void FireWeapon()
    {
        GameObject obj = Instantiate(coneColliderPrefab, firePoint.position, firePoint.rotation) as GameObject;
        obj.transform.parent = firePoint.transform;
        Destroy(obj, .3f);
    }
}
