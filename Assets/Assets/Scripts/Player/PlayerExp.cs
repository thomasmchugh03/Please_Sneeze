using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{

    public float exp = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getEXP()
    {
        return exp;
    }

    public void addEXP(float experience)
    {
        exp += experience;
    }

    public void subEXP(float experience)
    {
        exp -= experience;
    }

}
