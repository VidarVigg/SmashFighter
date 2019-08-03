using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnerConfig
{
    public Transform[] transforms = new Transform[4];
    public GameObject enemyPrefab;
}
