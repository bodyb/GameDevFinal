using NUnit.Framework;
using System.Xml;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public int waveNumber = 5;
    public int spawnPerWave = 10;
    public GameObject[] zombiePrefab;
    public int currentZombies;
    public bool waveDone = false;
    public GameObject winScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRound();
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Little_Ghost_ZOMbi (1)(Clone)") == null 
            && GameObject.Find("Little_Ghost_ZOMbi (2)(Clone)") == null 
            && GameObject.Find("Little_Ghost_ZOMbi (3)(Clone)") == null 
            && GameObject.Find("Little_Ghost_ZOMbi (4)(Clone)") == null
            && GameObject.Find("Little_Ghost_ZOMbi (5)(Clone)") == null
            && GameObject.Find("Little_Ghost_ZOMbi (6)(Clone)") == null
            && GameObject.Find("Little_Ghost_ZOMbi (7)(Clone)") == null
            && GameObject.Find("Little_Ghost_ZOMbi (8)(Clone)") == null
            && GameObject.Find("Little_Ghost_ZOMbi (9)(Clone)") == null)
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
            int ranZombie = Random.Range(0, zombiePrefab.Length);
            Instantiate(zombiePrefab[ranZombie], spawnPoints[ranSpawn].transform.position, spawnPoints[ranSpawn].transform.rotation);
        }
    }
}
