using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fruit : MonoBehaviour
{
    public int score = 1;

    private ClassicGameManager gameManager;
    private void Start()
    {
        gameManager = ClassicGameManager.Instance;
    }

    public void OnDisable()
    {
        if (gameManager != null)
        {
        gameManager.UpdateScore(score);
        gameManager.UpdateCombo();

        }
    }
}
