using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static bool isGameEnd = false;

    public float timerStart;
    public float heightDelta;
    public GameObject terrain;
    public Vector3 terrainSpawnPoint;

    private float timer;
    private float spawnedTerrainHeight;
    private float previousSpawnedTerrainHeight = -5.0f;
    private int oldTime;
    private int newTime;
    private GameObject terrainParent;

    private void Start()
    {
        timer = timerStart;
        oldTime = (int)Time.time;
        terrainParent = GameObject.Find("Terrains");
    }

    private void Update()
    {

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else 
        {
            timer = 0;
            isGameEnd = true;
        }
        if (!isGameEnd)
        {
            newTime = (int)Time.time;
            if (oldTime != newTime)
            {
                oldTime = newTime;
                SpawnTerrain();
            }
        }
    }

    private void SpawnTerrain()
    {
        spawnedTerrainHeight = Random.Range(0.0f, 1.0f) < 0.5f ? previousSpawnedTerrainHeight + 0.8f * heightDelta : previousSpawnedTerrainHeight - 0.8f * heightDelta;
        previousSpawnedTerrainHeight = spawnedTerrainHeight;
        Instantiate(terrain, new Vector3(terrainSpawnPoint.x, spawnedTerrainHeight, 0), Quaternion.identity).transform.parent = terrainParent.transform;
    }

    public float GetTimer()
    {
        return timer;
    }
    public void ModifyTimer(float time)
    {
        timer += time;
    }
}
