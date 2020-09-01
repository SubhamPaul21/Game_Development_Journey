using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDisableObject = 2f;
    private void OnEnable() 
    {
        Invoke("Hide", timeToDisableObject);    
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

}
