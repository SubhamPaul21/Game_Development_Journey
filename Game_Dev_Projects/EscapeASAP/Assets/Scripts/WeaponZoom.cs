using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedInFOV = 30f;
    [SerializeField] float zoomedOutFOV = 60f;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ZoomWeapon();
    }

    void ZoomWeapon()
    {
        if (Input.GetMouseButton(1))
        {
            mainCamera.fieldOfView = zoomedInFOV;
        }
        else
        {
            mainCamera.fieldOfView = zoomedOutFOV;
        }
    }
}
