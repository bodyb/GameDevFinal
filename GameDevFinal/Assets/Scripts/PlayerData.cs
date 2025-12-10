using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float playerHealth = 1;
    public bool alive = true;
    public HealthBarSc healthBar;
    public GameObject deadScreen;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deadScreen.SetActive(false);
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = healthBar.currentHealth;
        if (playerHealth == 0)
        {
            deadScreen.SetActive(true);
            alive = false;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<isZombie>())
        {
            healthBar.DamagePlayer(other.GetComponentInParent<isZombie>().damage);
            playerHealth = healthBar.currentHealth;
        }

    }

}
