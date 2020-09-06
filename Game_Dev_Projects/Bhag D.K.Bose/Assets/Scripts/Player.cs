using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 3.1f;
    Rigidbody playerRigidBody;
    Animator animator;
    bool isGrounded;
    Vector3 jump;

    void Start()
    {
        jump = new Vector3(0f, 2f, 0f);
        playerRigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && isGrounded)
        {
            ProcessJump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            ProcessJump();
        }
    }

    void ProcessJump()
    {
        playerRigidBody.AddForce(jump * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("Jump");
        isGrounded = false;
    }   

    private void OnCollisionStay(Collision other) 
    {
        isGrounded = true;   
    }

    private void OnCollisionExit(Collision other) 
    {
        isGrounded = false; 
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Obstacle")
        {
            // Method to process player death
            GameManager.Instance.EndGame();
        }    
    }

    
}
