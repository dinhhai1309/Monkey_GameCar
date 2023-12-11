using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackground : DestroyObject
{
    public float deadClound;
    private void Start()
    {
        deadClound = -25f;
    }
    protected override bool CanDespawn()
    {
        if (transform.position.x < deadClound) return true;
        return false;
    }
}
