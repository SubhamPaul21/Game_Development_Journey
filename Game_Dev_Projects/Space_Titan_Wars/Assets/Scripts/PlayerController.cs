using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [Header("General")]
    [SerializeField] float controlSpeed = 25f;
    [SerializeField] float xClamp = 11f;
    [SerializeField] float yClamp = 5f;
    [SerializeField] GameObject[] guns;

    [Header("Position Factors")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 3.5f;

    [Header("Control Factors")]
    [SerializeField] float controlPitchFactor = 2f;
    [SerializeField] float controlRollFactor = 25f;

    float horizontalThrow, verticalThrow;
    bool isPlayerDead = false;
    // Update is called once per frame
    void Update()
    {
        if (!isPlayerDead)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessTranslation()
    {
        // X Position
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetValue = controlSpeed * horizontalThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffsetValue;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClamp, xClamp);

        // Y Position
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetValue = controlSpeed * verticalThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffsetValue;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClamp, yClamp);

        // Set the local position
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        // Pitch
        float pitchPosition = transform.localPosition.y * positionPitchFactor;
        float pitchControl = horizontalThrow * controlPitchFactor;
        float pitch =  pitchPosition + pitchControl;
        // Yaw
        float yaw = transform.localPosition.x * positionYawFactor;
        // Roll
        float roll = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            ParticleSystem.EmissionModule emission = gun.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;
        }
    }

    private void StopMovement() // called by string reference
    {
        isPlayerDead = true;
    }
}
