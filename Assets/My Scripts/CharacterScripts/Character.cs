using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig characterConfig = new CharacterConfig();
    [SerializeField] private CharacterData data = new CharacterData();
    [SerializeField] private AttackType activeAttack;
    public AttackType ActiveAttack
    {
        get { return activeAttack; }
        set { activeAttack = value; }
    }

    private void Awake()
    {
        MovementManager movementManager = GetComponent<MovementManager>();
        Rotation(data.AttackDirection);

        if (!movementManager)
        {
            return;
        }
        data.Attacker = FindObjectOfType<Attacker>();
        movementManager.directionDelegate += Rotation;
        movementManager.attackDirDelegate += AttackDirection;
    }

    private void Rotation(int value)
    {
        data.Direction = value;
    }
    private void AttackDirection(int value)
    {
        data.AttackDirection = value;
    }

    public CharacterData Data
    {
        get { return data; }
    }

}
