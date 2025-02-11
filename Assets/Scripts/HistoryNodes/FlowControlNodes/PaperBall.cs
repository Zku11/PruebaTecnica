using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
this script throws an event when the ball enters the basket
 */

public class PaperBall : MonoBehaviour
{
    [SerializeField] BasketGame basketGame;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("basketDetection"))
        {
            basketGame.Dunk();
        }
    }
}
