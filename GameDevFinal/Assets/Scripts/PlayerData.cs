using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float playerHealth = 1;
    public bool alive = true;
    public HealthBarSc healthBar;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTrigger(Collider other)
    {

        if (other.GetComponentInParent<isZombie>())
        {
            healthBar.DamagePlayer(other.GetComponentInParent<isZombie>().damage);
            playerHealth = healthBar.currentHealth;
            Debug.Log("hit ahhhhhhhhhhh");
        }

    }

}
