using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : Attack
{

    private int direction;

    private float startAngle;

    private float maxAngle;

    private Coroutine executeRoutine;

    private TrailRenderer trailRenderer;

    public override void Execute()
    {
        Debug.Log("Bash Executed");

        direction = attacker.character.Data.Direction;
        startAngle = (attackData as BashAttackData).angle * direction;
        maxAngle = startAngle + (50 * direction);

        if (executeRoutine == null)
        {
           executeRoutine = StartCoroutine(ExecuteRoutine());
        }
    }

    private IEnumerator ExecuteRoutine()
    {
        weapon.rotation = Quaternion.Euler(0, 0, startAngle);
        if (direction > 0)
        {
            do
            {
                weapon.Rotate(0, 0, -(attackData as BashAttackData).speed * direction);
                yield return null;
            } while ((weapon.rotation.eulerAngles.z <= startAngle) || (weapon.rotation.eulerAngles.z > maxAngle));
        }
        else
        {
            do
            {
                weapon.Rotate(0, 0, -(attackData as BashAttackData).speed * direction);
                yield return null;
            } while (weapon.rotation.eulerAngles.z >= (360 + startAngle) || weapon.rotation.eulerAngles.z < (360 + maxAngle));
        }
        executeRoutine = null;

    }
    

    public override void Initialize(AttackData data)
    {
        trailRenderer = GetComponentInParent<TrailRenderer>();
        
        attackData = (BashAttackData)data;


    }
}
