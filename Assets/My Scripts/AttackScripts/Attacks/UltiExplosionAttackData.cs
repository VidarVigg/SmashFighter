using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UltiExplosion", menuName = "AttackData/UltiExplosion")]
public class UltiExplosionAttackData : AttackData
{
    public float force;
    public override AttackData GetInstance()
    {
        UltiExplosionAttackData data = CreateInstance<UltiExplosionAttackData>();
        data.force = force;
        return data;
    }
}
