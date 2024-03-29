using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAirController : MonoBehaviour
{
    [Header("Movement")]

    public float horizontalMovementSpeed;
    public float verticalMovementSpeed;


    [Header("Machine Parts")]

    public Transform HorizontalCam;
    public Transform VerticalCam;

    [Header("Firing")]

    public Rigidbody bullet;
    public float bulletVelocity;
    public float fireRate;
    public Transform leftBarrel;
    public Transform rightBarrel;

    float verticalRotation = 0f;
    float time = 0f;
    bool fireOrientation = false;

    void Start()
    {
        
    }



    void Update()
    {
        time += Time.deltaTime;




        if(Input.GetKey(KeyCode.RightArrow))
        {
            HorizontalCam.transform.Rotate(0, horizontalMovementSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            HorizontalCam.transform.Rotate(0, -horizontalMovementSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) && verticalRotation > -90f)
        {
            VerticalCam.transform.Rotate(-verticalMovementSpeed * Time.deltaTime, 0, 0);
            verticalRotation -= verticalMovementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) && verticalRotation < 0f)
        {
            VerticalCam.transform.Rotate(verticalMovementSpeed * Time.deltaTime, 0, 0);
            verticalRotation += verticalMovementSpeed * Time.deltaTime;
        }



        if (Input.GetKey(KeyCode.Space) && time >= fireRate)
        {
            if(fireOrientation)
            {
                Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, rightBarrel.position, rightBarrel.rotation);
                bulletClone.GetComponent<Rigidbody>().AddForce(rightBarrel.forward * bulletVelocity);
                fireOrientation = false;
            }
            else
            {
                Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, leftBarrel.position, leftBarrel.rotation);
                bulletClone.GetComponent<Rigidbody>().AddForce(leftBarrel.forward * bulletVelocity);
                fireOrientation = true;
            }

            time = 0;
        }





    }
}
