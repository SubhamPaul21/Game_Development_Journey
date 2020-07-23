using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    // state variables
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 5f;

    //member variables
    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f; // Approx to 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // Sin restricts between -1 to +1
        float movementFactor = rawSinWave / 2f + 0.5f; // Divide by 2 to clamp b/w -0.5 to +0.5, then add 0.5 to clamp b/w 0 to 1
        print(movementFactor);
        Vector3 offsetPos = movementVector * movementFactor;
        transform.position = startingPos + offsetPos;
    }
}
