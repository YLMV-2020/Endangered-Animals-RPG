using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusLogic : MonoBehaviour
{
    public float initial = -10;
    public float final = 20;

    bool bandera = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.z);
        if (transform.position.z > 20 && !bandera)
        {
            bandera = true;
        }
        else if (transform.position.z < 0 && bandera) 
        {
            bandera = false;
            //transform.position -= new Vector3(0, 0, Time.deltaTime * 5);

        }

        if(!bandera)
            transform.position += new Vector3(0, 0, Time.deltaTime * 5);
        else
            transform.position -= new Vector3(0, 0, Time.deltaTime * 5);
            

    }
}
