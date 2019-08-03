using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppercut : Attack
{
    private int direction;
    private float startAngle;
    private float maxAngle;


    public override void Execute()
    {
        Debug.Log("Uppercut Executed");

        direction = attacker.character.Data.AttackDirection;
        startAngle = (attackData as UppercutAttackData).angle * direction;
        maxAngle = startAngle - (1 * direction);

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
                weaponTransform.Rotate(0, 0, (attackData as UppercutAttackData).speed * direction);
                yield return null;
            } while ((weaponTransform.rotation.eulerAngles.z >= startAngle) || (weaponTransform.rotation.eulerAngles.z < maxAngle));
        }
        else
        {
            do
            {
                weaponTransform.Rotate(0, 0, (attackData as UppercutAttackData).speed * direction);
                yield return null;
            } while (weaponTransform.rotation.eulerAngles.z <= (360 + startAngle) || weaponTransform.rotation.eulerAngles.z > (360 + maxAngle));
        }
        weapon.ControllWeaponColliderAndVisuals(false);
        executeRoutine = null;

    }

    public override void Initialize(AttackData data)
    {
        attackData = (UppercutAttackData)data;
    }


}
