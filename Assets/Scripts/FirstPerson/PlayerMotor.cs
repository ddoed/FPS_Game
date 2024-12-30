using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 0.88f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirecton = Vector3.zero;
        moveDirecton.x = input.x;
        moveDirecton.z = input.y;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;
        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(transform.TransformDirection(moveDirecton) * speed * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }

    public void StartSprinting()
    {
        speed = 10f;
    }

    public void StopSprinting()
    {
        speed = 5f;
    }
}
