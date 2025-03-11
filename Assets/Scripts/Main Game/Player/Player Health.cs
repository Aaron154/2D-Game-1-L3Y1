using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth;
    float currentHealth;

    public HUDManager HUD;
    public YouLose YouLose;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerMaxHealth;
        HUD.UpdateHealthBar(currentHealth/playerMaxHealth);
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        HUD.UpdateHealthBar(currentHealth/playerMaxHealth);
        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        YouLose.GameOver();
        Destroy(gameObject);
    }
}
