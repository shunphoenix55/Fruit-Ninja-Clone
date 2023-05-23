using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : SliceableObject
{
    public override void OnSlice()
    {
        gameManager.EndGame();
    }
}
