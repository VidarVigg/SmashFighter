using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private AttackData[] attackDatas = null;
    [SerializeField] private Attack[] attacks = null;
    private void Start()
    {
        InputManager.INSTANCE.attackDelegate += ExecuteAttack;
        Initialize();
    }

    private void Initialize()
    {
        AttackManager attackManager = AttackManager.INSTANCE;
        if (!attackManager)
        {
            return;
        }
        attacks = new Attack[attackDatas.Length];

        for (int i = 0; i < attackDatas.Length; i++)
        {
            Attack attack = attackManager.GetAttack(attackDatas[i].attackType);

            if (!attack)
            {
                continue;
            }
            attacks[i] = Instantiate(attack, FindObjectOfType<Weapon>().transform);
            // attacks[i].attackData = attackDatas[i];
            attacks[i].SetData(attackDatas[i].GetInstance());
        }
    }
    public void ExecuteAttack(int index)
    {
        attacks[index]?.Execute();
    }
}
