using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDetector : MonoBehaviour
{
    private ClassicGameManager gameManager;
    private void Awake()
    {
        gameManager = ClassicGameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.DestroyOutOfBounds(other.gameObject);
    }
}
