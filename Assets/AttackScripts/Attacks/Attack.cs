using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public AttackType attackType;
    public AttackData attackData;
    public Transform weapon;

    public Attacker attacker;

    public abstract void Execute();
    public abstract void Initialize(AttackData data);
} 
public enum AttackType
{
    Uppercut, 
    Bash,
}