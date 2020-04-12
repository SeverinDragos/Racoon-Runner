using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f;

    public float jumpPower = 40;

    private float jumpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // X
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        // Y
        moveVector.y = verticalVelocity;

        // Z
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && jumpTime > 1)
        {
            controller.Move(Vector3.up * jumpPower * Time.deltaTime);
            jumpTime = 0;
        }
        jumpTime += Time.deltaTime;

        
            
    }
}