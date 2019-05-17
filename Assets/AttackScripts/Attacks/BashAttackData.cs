using UnityEngine;

[CreateAssetMenu(fileName = "Bash", menuName ="AttackData/Bash")]

public class BashAttackData : AttackData
{
    [SerializeField] private float force;
    [SerializeField] private float damage;

    public override AttackData GetInstance()
    {
        BashAttackData data = CreateInstance<BashAttackData>();
        data.force = force;
        data.damage = damage;

        return data;
    }
}
