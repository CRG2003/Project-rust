using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //We don't stricly need this, but it could be used for adjustable difficulty.
    public int deathCount;

    public GameData()
    {
        this.deathCount = 0;
    }
}
