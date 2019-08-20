using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiExplosion : Attack
{
    public override void Execute()
    {
        Debug.Log("UltiExecuted");
    }

    public override void Initialize(AttackData data)
    {
        attackData = (UltiExplosionAttackData)data;
    }
}
