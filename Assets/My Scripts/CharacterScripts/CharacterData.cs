using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    [SerializeField] private int direction;
    [SerializeField] private int attackDirection;

    public int AttackDirection
    {
        get { return attackDirection; }
        set { attackDirection = value; }
    }

    public int Direction
    {
        get { return direction; }
        set { direction = value; }
    }

}
