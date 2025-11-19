using UnityEngine;
using UnityEngine.UI;

public class HealthBarSc : MonoBehaviour
{
   
    public Slider healthSlider;       

 
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
      
        currentHealth = maxHealth;

      
        healthSlider.minValue = 0f;
        healthSlider.maxValue = 1f;

        UpdateHealthUI();
    }


    public void DamagePlayer(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        UpdateHealthUI();
    }

    public void HealPlayer(float healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0f, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
