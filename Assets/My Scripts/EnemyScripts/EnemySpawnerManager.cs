using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private EnemySpawnerConfig config = new EnemySpawnerConfig();
    [SerializeField] private EnemySpawnerController controller = new EnemySpawnerController();


    private void Awake()
    {
        config.enemyPrefab = (GameObject)Resources.Load("Enemy");
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            GameObject enemyClone = Instantiate(config.enemyPrefab, controller.RandomSpawnpoint(config));
            yield return new WaitForSeconds(Random.Range(1, 5));
            yield return null;
        }
    }

}
