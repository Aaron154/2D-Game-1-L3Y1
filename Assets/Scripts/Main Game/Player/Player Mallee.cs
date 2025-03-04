using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage =10;
    public LineRenderer lineRenderer;

    private int circleSegments = 30;

    void Start()
    {
        DrawAttackRange();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) // Left-click to attack
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRange);
        if (enemy && enemy.CompareTag("Enemy"))
        {
            Health enemyHealth = enemy.GetComponent<Health>(); // Use Health script
            if (enemyHealth)
            {
                enemyHealth.TakeDamage(attackDamage); // Call TakeDamage function
            }
        }
    }

    void DrawAttackRange()
    {
        if (!lineRenderer) return;

        lineRenderer.positionCount = circleSegments + 1;
        lineRenderer.loop = true;

        for (int i = 0; i <= circleSegments; i++)
        {
            float angle = i * (2 * Mathf.PI / circleSegments);
            float x = Mathf.Cos(angle) * attackRange;
            float y = Mathf.Sin(angle) * attackRange;
            lineRenderer.SetPosition(i, new Vector3(attackPoint.position.x + x, attackPoint.position.y + y, 0));
        }
    }
}
