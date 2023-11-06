using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;

    //bounds
    private float xRangeRight = -3;
    private float xRangeLeft = -7;
    private float yRange = 6;

    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemy, GenerateSpawn(), enemy.transform.rotation);
    }

    private Vector2 GenerateSpawn()
    {
        float spawnPosX = Random.Range(xRangeRight, xRangeLeft);

        Vector2 randomPos = new Vector2(spawnPosX, yRange);

        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
