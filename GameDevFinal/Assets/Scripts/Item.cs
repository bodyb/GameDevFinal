using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speeed = 30f;
    public bool gunAmmo = false;
    public bool food = false;
    public bool grenadeAmmo = false;
    public GameObject player;
    //public HealthBarSc health;
    //public gunShooting gunShooting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.up * Mathf.Cos(Time.deltaTime)/10 * speeed);
        transform.Rotate(Vector3.up * speeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //Debug.Log("i touched");
            if (gunAmmo && !food && !grenadeAmmo) 
            {
                player.GetComponentInParent<gunShooting>().currentGun.currentTotalAmmo += 30;
                Destroy(gameObject);
            }
            if (!gunAmmo && food && !grenadeAmmo)
            {
                player.GetComponentInParent<PlayerData>().healthBar.HealPlayer(30f);
                Destroy(gameObject);
            }
            if (!gunAmmo && !food && grenadeAmmo)
            {
                player.GetComponentInParent<gunShooting>().grenadeAmmo += 2;
                Destroy(gameObject);
            }
        }
        
    }
}
