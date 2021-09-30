using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 1;
    int MaxDist = 2;
    int MinDist = 1;

    float yaw = 0.0f;
    float pitch = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);
        //transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            //yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 2.0f;

            //pitch -= 2.0f * Input.GetAxis("Mouse Y");

            //playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);

            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            //transform.localEulerAngles = Player.transform.eulerAngles;
            //transform.position = new Vector3(transform.position.x, 1f, transform.position.z); 
            


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                Debug.Log("Atrapado");
            }

        }
    }
}
