using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public AttackType attackType;
    public AttackData attackData;
    public abstract void Execute();
    public abstract void SetData(AttackData data);
}
public enum AttackType
{
    Uppercut, 
    Bash,
}