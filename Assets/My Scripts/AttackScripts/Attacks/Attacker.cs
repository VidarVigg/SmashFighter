using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Instantiates and initializes attacks based on available attack datas.
[RequireComponent (typeof(Character))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private AttackData[] attackDatas = null;
    [SerializeField] private Attack[] attacks = null;
    [SerializeField] private AttackerData attackerData = new AttackerData();
    public Character character;
    private void Awake()
    {
       character = GetComponent<Character>();
    }
    private void Start()
    {
        attackerData.weapon = GetComponentInChildren<Weapon>().transform;
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
            attacks[i] = Instantiate(attack, transform);
            attacks[i].Initialize(attackDatas[i].GetInstance());
            attacks[i].weapon = attackerData.weapon;
            attacks[i].attacker = this;
        }
    }
    public void ExecuteAttack(int index)
    {
        attacks[index]?.Execute();
    }
}
