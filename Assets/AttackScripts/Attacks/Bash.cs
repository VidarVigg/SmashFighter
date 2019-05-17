using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : Attack
{
    public override void Execute()
    {
        Debug.Log("Bash Executed");
    }

    public override void SetData(AttackData data)
    {
        attackData = (BashAttackData)data;
    }
}
