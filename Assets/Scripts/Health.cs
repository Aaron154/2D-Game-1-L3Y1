using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
