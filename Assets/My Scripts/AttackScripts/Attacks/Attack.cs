using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Base Class for attacks
public abstract class Attack : MonoBehaviour
{
    public AttackType attackType;
    public AttackData attackData;
    public Transform weaponTransform;
    public Weapon weapon;
    public Attacker attacker;
    public abstract void Execute();
    public abstract void Initialize(AttackData data);
    public Coroutine executeRoutine;
} 
public enum AttackType
{
    Uppercut, 
    Bash,
}