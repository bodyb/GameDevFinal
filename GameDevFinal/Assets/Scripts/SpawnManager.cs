using JetBrains.Annotations;
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
    public float countDown;
    public float elaspedTime;
    public bool preWave = true;
    public bool startIt = false;
    public GameObject countTextScreen;
    public GameObject crossHair;
    public TMP_Text countText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveDone = true;
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        waveDone = waveOver();

        if (waveDone)
        {
            if (waveNumber >= 0)
            {
                preWave = true;
            }
        }
        if (preWave)
        {
            countDownFunction();
        }
        if (startIt)
        {
            elaspedTime = 0;
            startRound();
            waveDone = false;
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
        startIt = false;
    }

    void countDownFunction()
    {
        if (preWave)
        {
            countDown = Mathf.RoundToInt(7 - elaspedTime);
            elaspedTime += Time.deltaTime;
            countTextScreen.SetActive(true);
            crossHair.SetActive(false);
            if (countDown > 5.5)
            {
                countText.text = "Wave " + waveNumber;
            }
            else if (countDown <= 5.5)
            {
                countText.text = countDown.ToString();
                if (countDown < 0)
                {
                    countTextScreen.SetActive(false);
                    crossHair.SetActive(true);
                    preWave = false;
                    waveDone = true;
                    startIt = true;
                }
            }
        }
    }

    bool waveOver()
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
            return true;
        }
        else
        {
            return false;
        }
    }
}
