using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{// denna klass skall vara som en databas av attacker från resources. alltså de prefabs som finns i resources

    public Attack[] attacks = new Attack[0];
    public static AttackManager INSTANCE;
    private void Awake()
    {
        if (!INSTANCE)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
       attacks = Resources.LoadAll<Attack>("Attacks");
    }
    public Attack GetAttack(AttackType attackType)
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            if (attacks[i].attackType == attackType)
            {
                return attacks[i];
            }
        }
            return null;
    }

}
