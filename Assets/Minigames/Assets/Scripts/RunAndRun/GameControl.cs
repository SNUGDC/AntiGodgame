using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static bool isGameEnd = false;

    public float timerStart;
    public float runSpeedByMeterPerSec;
    public GameObject terrain;
    public Vector3 terrainSpawnPoint;
    public Text debugText;
    public Text timerText;
    public Text runMeterText;

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
        timerText.text = "TIMER: " + timer.ToString("N2");

        if(timer > 0)
        {
            timer -= Time.deltaTime;
            runMeterText.text = "RUN: " + (Time.time * runSpeedByMeterPerSec).ToString("N2") + "m";
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
