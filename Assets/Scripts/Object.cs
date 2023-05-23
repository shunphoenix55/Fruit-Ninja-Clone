using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class SliceableObject : MonoBehaviour
{
    public int score = 1;

    protected ClassicGameManager gameManager;
    private void Start()
    {
        gameManager = ClassicGameManager.Instance;
    }

    public abstract void OnSlice();
}
