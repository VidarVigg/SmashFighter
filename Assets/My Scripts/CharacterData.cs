using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    [SerializeField] private int direction;

    public int Direction
    {
        get { return direction; }
        set { direction = value; }
    }

}
