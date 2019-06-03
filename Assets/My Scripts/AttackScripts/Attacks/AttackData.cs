using UnityEngine;

public abstract class AttackData : ScriptableObject
{
    public AttackType attackType;
    public abstract AttackData GetInstance();
}
