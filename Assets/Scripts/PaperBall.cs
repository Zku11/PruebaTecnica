using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
