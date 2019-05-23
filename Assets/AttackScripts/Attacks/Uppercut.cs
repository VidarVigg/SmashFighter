using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppercut : Attack
{
    [SerializeField] UppercutData data = new UppercutData();

    public override void Execute()
    {
        if (attacker.character.Data.Direction == 1)
        {

        }
        else
        {

        }
        
        Debug.Log("Uppercut Executed");
        weapon.rotation = data.uppercutOriginRotation;
    }

    public override void Initialize(AttackData data)
    {
        attackData = (UppercutAttackData)data;
    }
}
