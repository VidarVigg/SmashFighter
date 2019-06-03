using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Class that acts like a database of available attacks in resources.
public class AttackManager : MonoBehaviour
{
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
