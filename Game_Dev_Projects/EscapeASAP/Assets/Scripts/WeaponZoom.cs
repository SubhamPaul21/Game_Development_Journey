using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    [Header("Field of View")]
    [SerializeField] float zoomedInFOV = 30f;
    [SerializeField] float zoomedOutFOV = 60f;

    [Header("Sensitivity")]
    [SerializeField] float zoomedInSensitivity = 1f;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [Space] [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;

    // Update is called once per frame
    void Update()
    {
        ZoomWeapon();
    }

    void ZoomWeapon()
    {
        if (Input.GetMouseButton(1))
        {
            fpsCamera.fieldOfView = zoomedInFOV;
            firstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
            firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
        }
        else
        {
            fpsCamera.fieldOfView = zoomedOutFOV;
            firstPersonController.mouseLook.XSensitivity = zoomedOutSensitivity;
            firstPersonController.mouseLook.YSensitivity = zoomedOutSensitivity;
        }
    }
}
