﻿
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float maxSpeed = 5f;
    public GameObject explosion;
<<<<<<< HEAD

	public bool isGrounded = false;
    private Vector3 spawnPosition;

=======
    private Vector3 spawnPosition;
    private bool isGrounded;
>>>>>>> origin/master
	public Transform cam;

    void Start()
    {
        //spawnRotation = Quaternion.identity;
        spawnPosition = transform.position;
        Screen.showCursor = false;
    }


    void Update() 
	{

	        Vector3 cameraRelativeForward = cam.TransformDirection(Vector3.forward);
		
	       	Vector3 cameraRelativeRight = cam.TransformDirection(Vector3.right);
	    
	        Vector3 cameraRelativeLeft = cam.TransformDirection(Vector3.left);
	        
	        Vector3 cameraRelativeBack = cam.TransformDirection(Vector3.back);


        if (transform.position.y >= 0.45 || transform.position.y <= 0.55)
		{
       
        if (transform.position.y < .55)
			{

                if(Input.GetButton("Forward"))
                {
                    rigidbody.MovePosition(rigidbody.position + cameraRelativeForward * moveSpeed * Time.deltaTime);
                }
                if(Input.GetButton("Left"))
                {
                    rigidbody.MovePosition(rigidbody.position + cameraRelativeLeft * moveSpeed * Time.deltaTime);
                }
                if(Input.GetButton("Right"))
                {
                    rigidbody.MovePosition(rigidbody.position + cameraRelativeRight * moveSpeed * Time.deltaTime);
                }
                if(Input.GetButton("Reverse"))
                {
                    rigidbody.MovePosition(rigidbody.position + cameraRelativeBack * moveSpeed * Time.deltaTime);
                }
			
            }
        }
     

     
        if (Input.GetButtonDown("TurnLeft"))
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            transform.Rotate(0, 90f, 0);
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        if (Input.GetButtonDown("TurnRight"))
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            transform.Rotate(0, -90f, 0);
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    

        if(Input.GetButtonDown("Reset"))
        {
            Die();
        }
    }


    void OnCollisionExit(Collision hit)
    {
        if(hit.transform.tag == "Ground")
            isGrounded = false;
    }

	void OnCollisionEnter(Collision hit)

    {
        if(hit.transform.tag == "Enemy")
            Die();


        if(hit.transform.tag == "Ground" || hit.transform.tag == "Wall")
        { 
            isGrounded = true;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

    }

    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        transform.position = spawnPosition;
        //Destroy(gameObject);
        //Instantiate(me, spawnPosition, spawnRotation);
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
