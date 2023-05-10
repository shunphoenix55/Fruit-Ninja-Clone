using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int score = 1;

    private ClassicGameManager gameManager;
    private void Start()
    {
        gameManager = ClassicGameManager.Instance;
    }
    public void OnDestroy()
    {
        gameManager.UpdateScore(score);
        gameManager.UpdateCombo();
    }
}
