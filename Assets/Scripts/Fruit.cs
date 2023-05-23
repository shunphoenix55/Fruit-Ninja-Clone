using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit : SliceableObject
{
    public override void OnSlice()
    {
        gameManager.UpdateScore(score);
    }
}

