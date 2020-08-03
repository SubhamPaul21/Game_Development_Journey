using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 30f;
    [SerializeField] float xClampThreshold = 2f;

    Rigidbody2D playerRigidBody;
    float dirX;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPlayerTranslation();
    }

    private void FixedUpdate()
    {
        ProcessPlayerVelocity();
    }

    private void ProcessPlayerTranslation()
    {
        // Movement for player
        dirX = Input.acceleration.x * playerSpeed;
        float xClampPos = Mathf.Clamp(transform.position.x, -xClampThreshold, xClampThreshold);
        transform.position = new Vector2(xClampPos, transform.position.y);
    }

    private void ProcessPlayerVelocity()
    {
        playerRigidBody.velocity = new Vector2(dirX, 0f);
    }
}
