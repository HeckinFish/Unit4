using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject powerup;

    public int enemyCount;
    public int waveNumber = 1;

    //bounds
    private float xRangeRight = -3;
    private float xRangeLeft = -7;
    private float yRange = 6;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerup, GenerateSpawnPowerup(), powerup.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemy, GenerateSpawn(), enemy.transform.rotation);
        }
    }

    private Vector2 GenerateSpawn()
    {
        float spawnPosX = Random.Range(xRangeRight, xRangeLeft);

        Vector2 randomPos = new Vector2(spawnPosX, yRange);

        return randomPos;
    }

    private Vector2 GenerateSpawnPowerup()
    {
        float spawnPosX = Random.Range(18, -10);
        float spawnPosY = Random.Range(3, -10);

        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);

        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            Instantiate(powerup, GenerateSpawnPowerup(), powerup.transform.rotation);
            waveNumber++; SpawnEnemyWave(waveNumber);
        }
    }
}
