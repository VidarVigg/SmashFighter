using UnityEngine;

[CreateAssetMenu(fileName = "Uppercut", menuName = "AttackData/Uppercut")]

public class UppercutAttackData : AttackData
{

    [SerializeField] private float force;
    [SerializeField] private float damage;
    [SerializeField] public float angle;
    public float speed;

    public override AttackData GetInstance()
    {
        UppercutAttackData data = CreateInstance<UppercutAttackData>();
        data.force = force;
        data.damage = damage;
        data.angle = angle;
        data.speed = speed;
        return data;
    }
}
