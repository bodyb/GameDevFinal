using UnityEngine;

public class helpSpawner : MonoBehaviour
{
    public GameObject[] helpItems;
    public GameObject[] spawnpoints;
    public float startDelay = 1;
    public float delay = 6;
    public float yoffset = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnItem", startDelay, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem()
    {
        int item = Random.Range(0, helpItems.Length);
        int location = Random.Range(0, spawnpoints.Length);
        Instantiate(helpItems[item], new Vector3(spawnpoints[location].transform.position.x, spawnpoints[location].transform.position.y + yoffset, spawnpoints[location].transform.position.z), spawnpoints[location].transform.rotation);
    }
}
