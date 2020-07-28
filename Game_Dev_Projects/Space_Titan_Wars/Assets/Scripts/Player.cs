using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 25f;
    
    [Header("Clamped Values")]
    [SerializeField] float xClamp = 10f;
    [SerializeField] float yClamp = 5f;

    [Header("Rotation Factors")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = 2f;
    [SerializeField] float positionYawFactor = -1f;
    [SerializeField] float controlRollFactor = 20f;


    float horizontalThrow, verticalThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
    private void ProcessTranslation()
    {
        // X Position
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetValue = speed * horizontalThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffsetValue;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClamp, xClamp);

        // Y Position
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetValue = speed * verticalThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffsetValue;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClamp, yClamp);

        // Set the local position
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

}
