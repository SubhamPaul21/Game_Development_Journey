using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    void Update()
    {
        ProcessUserInput();
    }

    void ProcessUserInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("User clicked left mouse");
        }
    }
}
