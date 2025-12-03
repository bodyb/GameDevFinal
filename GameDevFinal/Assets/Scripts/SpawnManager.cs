using NUnit.Framework;
using System.Xml;
using TMPro;
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
    public GameObject winScreen;
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
        if (waveDone && waveNumber < 0)
        {
            winScreen.SetActive(true);
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
