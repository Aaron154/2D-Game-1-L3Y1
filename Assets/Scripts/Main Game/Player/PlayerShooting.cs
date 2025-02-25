using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializedField] public GameObject bulletPrefab;
    [SerializedField] public Transform firePointRotation;
    [SerializedField] public Transform bulletSpawnPoint;
    [SerializedField] public float bulletSpeed = 20f;
    [SerializedField] float attackRate = 2f;

    AudioSource audioSource;
    public AudioClip attacksound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePointRotation.right * bulletSpeed;
        Destroy(bullet, 10f);

    }
}