using NUnit.Framework;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public int waveNumber = 5;
    public int spawnCount;
    public int spawnPerWave = 10;
    public GameObject zombiePrefab;
    public int currentZombies;
    public bool waveDone = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("zombie(Clone)") == null)
        {
            waveDone = true;
        }
        if (waveDone)
        {
            waveNumber--;
            if (waveNumber >= 0)
            {
                startRound();
                waveDone = false;
            }
        }
    }

    void startRound()
    {
        waveNumber--;
        for (int i = 0; i < spawnPerWave; i++)
        {
            int ranSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(zombiePrefab, spawnPoints[ranSpawn].transform.position, spawnPoints[ranSpawn].transform.rotation);
        }
    }
}
