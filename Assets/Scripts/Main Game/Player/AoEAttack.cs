using UnityEngine;
using System.Collections;

public class AoEAttack : MonoBehaviour
{
    // Notes Are Put Above The Code Line/Script Sector

    // Size Of Attack
    public float attackRange = 1.5f;
    // Damage Of Attack
    public int damage = 10;
    // Cooldown Of Attack
    public float cooldown = 0.6f;
    // Make The Attack Visual Actually Visable
    public GameObject attackVisual;

    // Can The Attack Be Done?
    private bool canAttack = true;
    // This Is To Make Sure that Slow-Mo Is On Or Off
    private bool isSlowMoActive = false;


    void Update()
    {
        // Identify Left Click And CD To Attack
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            Attack();
            // Disable Attack Visual After 0.2 Seconds
            StartCoroutine(HideAttackVisual());
            StartCoroutine(AttackCooldown());
        }
    }

    void Attack()
    {
        // Enable Attack Visual
        attackVisual.SetActive(true);
        // Complex Code To Detect Enemies
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Health health = enemy.GetComponent<Health>();
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

                if (health != null)
                {
                    // This Deals The Damage
                    health.TakeDamage(damage);

                    // If The Target Has A Rigidbody2D, Apply Knockback In A Circle
                    if (rb != null)
                    {
                        Vector2 direction = (enemy.transform.position - transform.position).normalized;
                        // This Is The Knockback Force
                        rb.AddForce(direction * 500f);
                    }

                    if (!isSlowMoActive)
                    {
                        StartCoroutine(SlowMoEffect());
                    }
                    
                }
                
            }
        }
    }
    // This Should Be Self Explanatory By The Name
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }

    IEnumerator HideAttackVisual()
    {
         yield return new WaitForSeconds(0.2f);
         // This Makes Sure That The Attack Isn't Stuck To On If Spammed
         if (attackVisual.activeSelf)
         {
             attackVisual.SetActive(false);
         }

    }

    IEnumerator SlowMoEffect()
    {
        isSlowMoActive = true;
        // Slow-Mo To 20% Speed
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(0.2f);
        // Return To Normal Speed
        Time.timeScale = 1f;
        isSlowMoActive = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
