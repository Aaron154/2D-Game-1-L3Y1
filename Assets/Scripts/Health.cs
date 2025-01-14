using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;

    private void once()
    {
        Debug.Log(this + "Is In The Game");
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(this + " Took " + damage + " Damage");

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
