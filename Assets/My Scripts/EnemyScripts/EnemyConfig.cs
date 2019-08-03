using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyConfig
{
    [SerializeField]private LayerMask lm;
    public LayerMask Lm
    {
        get { return lm; }
        set { lm = value; }
    }
}
