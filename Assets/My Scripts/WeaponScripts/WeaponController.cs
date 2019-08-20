using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController
{

    Vector2 CalculateRaycastDirection(AttackType type)
    {
        if (type == AttackType.Bash)
        {
            return new Vector2(1, 0);
        }
        else
        {
            return new Vector2(-1, 0);
        }
    }

    public Vector2 GetCoordinateByRaycast(WeaponData data, Transform weapon, AttackType type)
    {
        data.hit = Physics2D.Raycast(data.rayOrigin.transform.position, weapon.transform.TransformDirection(CalculateRaycastDirection(type) * data.direction), Mathf.Infinity, data.layerMask);
        Debug.Log("Transform vector " + weapon.transform.TransformVector(CalculateRaycastDirection(type)));
        Debug.Log(data.hit.point);
        Debug.DrawRay(data.rayOrigin.transform.position, weapon.transform.TransformDirection(CalculateRaycastDirection(type) * 1000 * data.direction), Color.green, 2f);
        return data.hit.point;
    }



}
