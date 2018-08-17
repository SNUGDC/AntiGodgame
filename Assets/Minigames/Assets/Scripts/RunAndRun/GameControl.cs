using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static bool isGameEnd = false;

    public float timerStart;
    public GameObject terrain;
    //public GameObject[] obstacle;
    public Vector3 terrainSpawnPoint;

    public Text debugText;

    private float timer;
    private float spawnedTerrainHeight;
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
        debugText.text = Time.time.ToString();
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
        spawnedTerrainHeight = Random.Range(-5, -2);
        Instantiate(terrain, new Vector3(terrainSpawnPoint.x, spawnedTerrainHeight, 0), Quaternion.identity).transform.parent = terrainParent.transform;
    }
    public void ModifyTimer(float time)
    {
        timer += time;
    }
}
