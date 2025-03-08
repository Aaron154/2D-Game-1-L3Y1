using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 2.5f;
    public int attackDamage = 10;
    public LineRenderer lineRenderer;
    public float attackFillDuration = 0.1f; // How long the circle stays filled
    public float attackCooldown = 0.8f;

    private int circleSegments = 30; // Line Renderer Components
    private bool isFilling = false;
    private float fillTimer = 0f;
    private float cooldownTimer = 0f;

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && cooldownTimer <= 0)
        {
            Attack();
            isFilling = true;
            fillTimer = attackFillDuration;
            cooldownTimer = attackCooldown;
        }

        if (isFilling)
        {
            fillTimer -= Time.deltaTime;
            if (fillTimer <= 0)
            {
                isFilling = false;
            }
        }

        DrawAttackRange();
    }

    void Attack()
    {
        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRange);
        if (enemy && enemy.CompareTag("Enemy"))
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth)
            {
                enemyHealth.TakeDamage(attackDamage);
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

        // Fill Effect When Attacking
        if (isFilling)
        {
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
        else
        {
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
        }
    }
}
