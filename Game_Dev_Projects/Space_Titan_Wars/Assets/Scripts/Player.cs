using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    private void MovementInput()
    {
        // X Position
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetValue = speed * horizontalThrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffsetValue;
        float clampedXPos = Mathf.Clamp(rawXPos, -12f, 12f);

        // Y Position
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetValue = speed * verticalThrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffsetValue;
        float clampedYPos = Mathf.Clamp(rawYPos, -6f, 6f);

        // Set the local position
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

}
