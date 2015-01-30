
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float maxSpeed = 5f;
    public GameObject explosion;
    private Vector3 spawnPosition;


    void Start()
    {
        spawnPosition = transform.position;
        Screen.showCursor = false;
    }


    void Update()
    {
        #region Movement
        if (transform.position.y < .55)
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
        #endregion

        #region turn
        if (Input.GetButtonDown("TurnLeft"))
        {
            transform.Rotate(0, 90f, 0);
        }
        if (Input.GetButtonDown("TurnRight"))
        {
            transform.Rotate(0, -90f, 0);
        }
        #endregion

        if (Input.GetButtonDown("Reset"))
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
            Die();
    }

    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        transform.position = spawnPosition;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }
}
