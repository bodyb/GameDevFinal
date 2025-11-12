using UnityEngine;
using UnityEngine.UI;

public class HealthBarSc : MonoBehaviour
{
    public Slider health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //damagePlayer(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (health.value < 0)
        {
            health.value = 0;
        }
        if (health.value > 1)
        {
            health.value = 1;
        }

    }

    public void damagePlayer(float damage)
    {
        health.value = health.value - damage;
    }

    public void healPlayer(float heal)
    {
        health.value = heal + health.value;
    }
}
