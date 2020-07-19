using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    private Rigidbody rocketRigidBody;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            rocketRigidBody.AddRelativeForce(Vector3.up);
        }
        else
        {
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime);
        }
    }
}
