using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnerController
{
    public Transform RandomSpawnpoint(EnemySpawnerConfig config)
    {
        int rand = Random.Range(0, 4);
        return config.transforms[rand];
    }
}
