using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cut") && gameObject.tag == "Fruit")
        {
            ShowScore.Instance.IncrementScore(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Cut") && gameObject.tag == "Grenade")
        { 
            // End game
        }
    }
}
