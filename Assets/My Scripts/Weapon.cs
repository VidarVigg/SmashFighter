using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponConfig weaponConfig = new WeaponConfig();

    public void ExecuteAttack()
    {
        Debug.Log("Execute Attack");
    }

}
