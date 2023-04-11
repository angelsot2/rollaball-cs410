using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpforce = 0;
    public int jumpcount = 0;
    Rigidbody rb;
    bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.0f)) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        if (isGrounded) {
            jumpcount = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpcount < 1)) {
            jumpcount++;
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
}