using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f;
    [SerializeField]private float gravity = -9.81f * 2;
    [SerializeField]private float jump = 3f;
    
    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundDistance = 0.4f;
    [SerializeField]private LayerMask groundMask;
    [SerializeField]private CharacterController controller;

    private Vector3 movement;

    [SerializeField]private bool isGrounded;
   
    void Update()
    {
       // isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isGrounded = Physics.Raycast(groundCheck.position,Vector3.down, groundDistance,groundMask);

 
        if (isGrounded && movement.y < 0)
        {
            movement.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
 
        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * moveSpeed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            movement.y = Mathf.Sqrt(jump * -2f * gravity);
        }
 
        movement.y += gravity * Time.deltaTime;
 
        controller.Move(movement * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}