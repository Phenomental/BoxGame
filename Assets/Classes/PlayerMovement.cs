
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float maxSpeed = 5f;
    public GameObject explosion;
    private Vector3 userInput;
    private Vector3 spawnPosition;
    private bool isGrounded;


    void Start()
    {
        spawnPosition = transform.position;
        isGrounded = false;
        Screen.showCursor = false;
    }


    void Update() 
	{
        //Transform camF = Camera.main.transform;
        //Vector3 cameraRelativeForward = camF.TransformDirection(Vector3.forward);

        //Transform camR = Camera.main.transform;
        //Vector3 cameraRelativeRight = camR.TransformDirection(Vector3.right);

        //Transform camL = Camera.main.transform;
        //Vector3 cameraRelativeLeft = camL.TransformDirection(Vector3.left);

        //Transform camB = Camera.main.transform;
        //Vector3 cameraRelativeBack = camB.TransformDirection(Vector3.back);

		//transform.LookAt(Cube.position);

        if (transform.position.y >= 0.45 || transform.position.y <= 0.55)
        {
            if (isGrounded)
            {
                if (Input.GetButton("Forward"))
                {
                    rigidbody.MovePosition(rigidbody.position + Vector3.forward * moveSpeed * Time.deltaTime);
                }
                if (Input.GetButton("Left"))
                {
                    rigidbody.MovePosition(rigidbody.position - Vector3.right * moveSpeed * Time.deltaTime);
                }
                if (Input.GetButton("Right"))
                {
                    rigidbody.MovePosition(rigidbody.position + Vector3.right * moveSpeed * Time.deltaTime);
                }
                if (Input.GetButton("Reverse"))
                {
                    rigidbody.MovePosition(rigidbody.position - Vector3.forward * moveSpeed * Time.deltaTime);
                }
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
                rigidbody.AddForce(0, 100f, 0);
        }

        if (Input.GetButtonDown("Reset"))
        {
            Die();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Ground")
            isGrounded = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
            Die();

        if (other.transform.tag == "Ground" || other.transform.tag == "Wall")
        { 
            isGrounded = true;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        transform.position = spawnPosition;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
