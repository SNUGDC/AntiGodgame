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
    private int frames = 0;
    private int spawningFrame;
    private GameObject terrainParent;
    private List<GameObject> spawnedList;
    private bool isTerrainMoveAvailable = true;
    private bool isTerrainOverlapped = false;
    private float overlapDistance;
    private int resultParameter = 0;

    private void Awake()
    {
        spawnedList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            spawnedList.Add(child.gameObject);
        }
    }
    private void Start()
    {
        timer = timerStart;
        terrainParent = GameObject.Find("Terrains");
        spawningFrame = (int)(1 * -0.08f / TerrainControl.moveSpeed/ Time.deltaTime);
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (isTerrainOverlapped)
            {
                MoveTerrainOnOverlap();
            }
        }
        else 
        {
            timer = 0;
            isGameEnd = true;
            ModifyPMParameter(resultParameter);
        }
        if (!isGameEnd)
        {
            SpawnTerrainWithTimeInterval();
        }
    }

    private void MoveTerrainOnOverlap(){
        foreach(GameObject terrain in spawnedList)
        {
            terrain.transform.position += new Vector3(overlapDistance, 0.0f, 0.0f);
        }
        terrainSpawnPoint += new Vector3(overlapDistance, 0.0f, 0.0f);
        overlapDistance = 0.0f;
        isTerrainOverlapped = false;
    }

    private void SetResultParameter(string str){
        if(str == "BAD"){

        }
    }

    private void ModifyPMParameter(int param){
        PlayerPref.SetInt("PM", PlayerPref.GetInt("PM") + param);
    }

    private void SpawnTerrainWithTimeInterval()
    {
        if(frames != spawningFrame)
        {
            frames++;
        }
        else
        {
            frames = 0;
            SpawnTerrain();
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
    public bool GetIsTerrainMoveAvailable()
    {
        return isTerrainMoveAvailable;
    }
    public void SetIsTerrainMoveAvailable(bool b)
    {
        isTerrainMoveAvailable = b;
    }
    public bool GetIsTerrainOverlapped()
    {
        return isTerrainOverlapped;
    }
    public void SetIsTerrainOverlapped(bool b)
    {
        isTerrainOverlapped = b;
    }
    public float GetOverlapDistance()
    {
        return overlapDistance;
    }
    public void SetOverlapDistance(float f)
    {
        overlapDistance = f;
    }
    public void AddElementOnSpawnedList(GameObject item)
    {
        spawnedList.Add(item);
    }
    public void DeleteElementOnSpawnedList(GameObject item)
    {
        spawnedList.Remove(item);
    }
}
