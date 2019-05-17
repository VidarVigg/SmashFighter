using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppercut : Attack
{
    
    public override void Execute()
    {
        Debug.Log("Uppercut Executed");
    }

    public override void SetData(AttackData data)
    {
        attackData = (UppercutAttackData)data;
    }
}
