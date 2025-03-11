using UnityEngine;
using System.Collections;

public class AoEAttack : MonoBehaviour
{
    // Notes Are Put Above The Code Line/Script Sector

    // Size Of Attack
    public float attackRange = 3f;
    // Damage Of Attack
    public int damage = 10;
    // Make The Attack Visual Actually Visable
    // public GameObject attackVisual;


    // Can The Attack Be Done?
    private bool canAttack = true;
    // This Is To Make Sure that Slow-Mo Is On Or Off
    // private bool isSlowMoActive = false;


    void Update()
    {
        // Identify Left Click And CD To Attack
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            Attack();
            // Disable Attack Visual After 0.2 Seconds
            // StartCoroutine(HideAttackVisual());
            StartCoroutine(AttackCooldown());
        }
    }

    void Attack()
    {
        // Enable Attack Visual
        // attackVisual.SetActive(true);
        // Complex Code To Detect Enemies
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        // HEAVY DEBUGGING
        if (enemies.Length == 0)
        {
            Debug.LogError("No enemies were detected in the attack radius.");
            return;
        }

        foreach (Collider2D enemy in enemies)
        {
            // HEAVY DEBUGGING
            // Debug.Log("Detected: " + enemy.gameObject.name);
            //Debug To Make Sure That The Attack hits The Enemy
            Debug.Log("Hit Detected: " + enemy.gameObject.name);
            // Prevent The Attack From Hitting The Player
            if (enemy.gameObject == gameObject || enemy.CompareTag("Player"))
            {
                // HEAVY DEBUGGING
                // Debug.LogWarning("⚠️ Skipped hitting the player.");
                continue;
            }

            if (enemy.CompareTag("Enemy"))
            {
                // HEAVY DEBUGGING
                // Debug.Log("Hit Detected On: " + enemy.gameObject.name);
                // Grabs The Health And The Rigidbody Of The Enemy
                Health health = enemy.GetComponent<Health>();
                Rigidbody2D rb2D = enemy.GetComponent<Rigidbody2D>();

                if (health != null)
                {
                    // HEAVY DEBUGGING
                    // Debug.Log("Damage Dealt To: " + enemy.gameObject.name);
                    // This Deals The Damage
                    health.TakeDamage(damage);

                    // If The Target Has A Rigidbody2D, Apply Knockback In A Circle
                    if (rb2D != null)
                    {
                        Vector2 direction = (enemy.transform.position - transform.position).normalized;
                        // This Is The Knockback Force
                        rb2D.AddForce(direction * 1000f, ForceMode2D.Impulse);
                        // HEAVY DEBUGGING
                        // Debug.Log("Knockback Applied To: " + enemy.gameObject.name);
                    }

                    // if (!isSlowMoActive)
                    // {
                    //     // HEAVY DEBUGGING
                    //     Debug.Log("Slow-Mo Triggered.");
                    //     StartCoroutine(SlowMoEffect());
                    // }
                    
                }
                // HEAVY DEBUGGING
                // else
                // {
                //     Debug.LogWarning("⚠️ No Health Script Found On: " + enemy.gameObject.name);
                // }

            }
            // HEAVY DEBUGGING
           // else
           // {
           //     Debug.LogWarning("⚠️ This object has NO 'Enemy' tag: " + enemy.gameObject.name);
           // }
        }
    }
    // This Should Be Self Explanatory By The Name
    IEnumerator AttackCooldown()
    {
        Debug.Log("Attack CD Started");
        canAttack = false;
        yield return new WaitForSeconds(0.4f);
        canAttack = true;
        Debug.Log("Attack CD Ended");
    }

    // IEnumerator HideAttackVisual()
    // {
    //      yield return new WaitForSeconds(0.2f);
    //      // This Makes Sure That The Attack Isn't Stuck To On If Spammed
    //      if (attackVisual.activeSelf)
    //      {
    //          attackVisual.SetActive(false);
    //     }
    // }

    // IEnumerator SlowMoEffect()
    // {
    //     isSlowMoActive = true;
    //     // Slow-Mo To 20% Speed
    //     Time.timeScale = 0.2f;
    //     yield return new WaitForSecondsRealtime(0.2f);
    //     // Return To Normal Speed
    //     Time.timeScale = 1f;
    //     Time.fixedDeltaTime = 0.02f;
    //     isSlowMoActive = false;
    // }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
