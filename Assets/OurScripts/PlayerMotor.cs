using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 20.0f;
    private float animationDuration = 3.0f;
    private float jumpSpeed = 9.0f;

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
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpSpeed - gravity * Time.deltaTime;
            }
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
    }
}