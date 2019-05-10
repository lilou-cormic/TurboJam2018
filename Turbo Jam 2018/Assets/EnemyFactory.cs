using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFactory : MonoBehaviour
{
    private static bool WaveHasEnded = false;

    public static int EnemyLeft;

    public Rigidbody2D EnemyPrefab;
    public Rigidbody2D EnemyFastPrefab;
    public Rigidbody2D MeteorPrefab;

    private float timeBetweenEnemies = 1f;
    private float timeLeft = 1f;

    private Rigidbody2D[] EnemyPrefabPool;

    private void Start()
    {
        WaveHasEnded = false;
        EnemyLeft = 0;

        EnemyPrefabPool = new Rigidbody2D[15];

        FillPool();
    }

    private void Update()
    {
        if (WaveHasEnded)
        {
            if (EnemyLeft <= 0)
            {
                timeLeft = 2f;
                timeBetweenEnemies = 1f;

                ScoreManager.AddWave();

                FillPool();

                WaveHasEnded = false;
                EnemyLeft = 0;
            }

            return;
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            SpawnEnemy();

            timeBetweenEnemies *= 0.97f;
            timeLeft = timeBetweenEnemies;
        }

        if (timeBetweenEnemies <= 0.3f)
            WaveHasEnded = true;
    }

    private void FillPool()
    {
        for (int i = 0; i < EnemyPrefabPool.Length; i++)
        {
            if (i < ScoreManager.WaveCount)
                EnemyPrefabPool[i] = MeteorPrefab;
            else if (i <= ScoreManager.WaveCount * 2)
                EnemyPrefabPool[i] = EnemyFastPrefab;
            else
                EnemyPrefabPool[i] = EnemyPrefab;
        }
    }

    private void SpawnEnemy()
    {
        EnemyLeft++;

        var enemy = Instantiate(EnemyPrefabPool[Random.Range(0, EnemyPrefabPool.Length)], Random.insideUnitCircle.normalized * 7.2f, Quaternion.identity);
        enemy.rotation = Mathf.Atan2(enemy.position.y, enemy.position.x) * Mathf.Rad2Deg - 90;
        enemy.velocity = enemy.position.normalized * -1 * enemy.GetComponent<Enemy>().Speed;
    }
}
