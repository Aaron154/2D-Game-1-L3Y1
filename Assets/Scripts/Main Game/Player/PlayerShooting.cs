using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public Transform firePointRotation;
    
    public Transform bulletSpawnPoint;

    public float bulletSpeed = 20f;
    float attackRate = 2f;

    AudioSource audioSource;
    public AudioClip attacksound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.isPaused)
        return;

        RotateBulletSpawnPointTowardsMouse();
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void RotateBulletSpawnPointTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - firePointRotation.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        firePointRotation.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    
    }
    void Shoot()
    {
        lastTimeShot = Time.time;


        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);
        bullet.transform.rotation = Quaternion.Euler(0, 0, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;
        audioSource.PlayOneShot(attackSound);
        Destroy(bullet, 10f);

    }
}