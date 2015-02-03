﻿
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float maxSpeed = 5f;
   
	public GameObject explosion;
    private static Vector3 spawnPosition;
	public Transform cam;

	public Transform playerTransform;

    void Start()
    {
		spawnPosition = transform.position;   
        Screen.showCursor = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		CameraTurn.player = this.gameObject;
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

	void OnCollisionEnter(Collision hit)

    {
        if(hit.transform.tag == "Enemy")
		{
            Die();
		}

        if(hit.transform.tag == "Ground" || hit.transform.tag == "Wall")
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }

 	 void Die()
    {
<<<<<<< HEAD
        audio.Play();
=======
        audio.Play();                                                   // Eksplosion (Lyd)
        Instantiate(explosion, transform.position, transform.rotation); // Eksplotsion
        Instantiate(playerTransform, spawnPosition, transform.rotation);// Ny Player
        Destroy(gameObject);                                            // Fjern gammel Player
>>>>>>> master

		Instantiate(explosion, transform.position, transform.rotation);

<<<<<<< HEAD
		Instantiate(playerTransform, spawnPosition, transform.rotation);

		Destroy(gameObject);
=======
         // MIDLERTIDIG LØSNING TIL RESPAWN-PROBLEM
        //Application.LoadLevel(Application.loadedLevel);
        // MIDLERTIDIG LØSNING TIL RESPAWN-PROBLEM
>>>>>>> master

		//rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

	}
}
