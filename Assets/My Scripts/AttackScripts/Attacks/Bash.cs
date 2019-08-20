using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bash : Attack
{

    private int direction;

    private float startAngle;

    private float maxAngle;




    public override void Execute()
    {
        Debug.Log("Bash Executed");
        direction = attacker.character.Data.AttackDirection;
        startAngle = (attackData as BashAttackData).angle * direction;
        maxAngle = startAngle + (70 * direction);

        if (executeRoutine == null)
        {
           executeRoutine = StartCoroutine(ExecuteRoutine());
        }
    }


    private IEnumerator ExecuteRoutine()
    {
        weaponTransform.rotation = Quaternion.Euler(0, 0, startAngle);
        weapon.ControllWeaponColliderAndVisuals(true);
        if (direction > 0)
        {
            do
            {
                weaponTransform.Rotate(0, 0, -(attackData as BashAttackData).speed * direction);
                yield return null;
            } while ((weaponTransform.rotation.eulerAngles.z <= startAngle) || (weaponTransform.rotation.eulerAngles.z > maxAngle));
        }
        else
        {
            do
            {
                weaponTransform.Rotate(0, 0, -(attackData as BashAttackData).speed * direction);
                yield return null;
            } while (weaponTransform.rotation.eulerAngles.z >= (360 + startAngle) || weaponTransform.rotation.eulerAngles.z < (360 + maxAngle));
        }
        weapon.ControllWeaponColliderAndVisuals(false);
        executeRoutine = null;

    }

    public override void Initialize(AttackData data)
    {   
        attackData = (BashAttackData)data;
    }


}
