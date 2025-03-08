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

        Debug.Log(this + " Took " + damage + " Damage");
        Debug.LogWarning(this + " Is Low On Health - " + currentHealth + " Out Of " + maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log(this + " Died");
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
