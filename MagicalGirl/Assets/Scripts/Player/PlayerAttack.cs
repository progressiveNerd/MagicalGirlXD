using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform shotPrefab;
    public int meleeDamage = 2;
    public float attackSpeed = 0.15f;
    public float shootingRange = 100f;
    public float meleeRange = 2f;
    public AudioClip meleeSound, shootSound;

    float attackTimer;
    float indicatorTimer;
    float indicatorLength;
    int shootableMask;
    AudioSource audioSource;
    PlayerMeleeIndicator indicator;
    Ray shootRay;
    RaycastHit shootHit;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        audioSource = GetComponent<AudioSource>();
        indicator = GameObject.FindWithTag("Indicator").GetComponent<PlayerMeleeIndicator>();
        indicatorLength = 0.5f;
    }

    void FixedUpdate()
    {
        attackTimer += Time.deltaTime;
        if (Input.GetButton("Fire1") && attackTimer >= attackSpeed && Time.timeScale != 0)
            Shoot();
        if (Input.GetButtonDown("Fire2") && attackTimer >= attackSpeed && Time.timeScale != 0)
            Melee();
    }

    private void Melee()
    {
        attackTimer = 0f;
        audioSource.clip = meleeSound;
        audioSource.Play();

        Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouse = mousePosVector - transform.position;
        playerToMouse.z = 0f;
        indicator.SetRotation(playerToMouse.normalized);

        shootRay.origin = transform.position;
        shootRay.direction = playerToMouse.normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerToMouse.normalized, meleeRange, shootableMask);
        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(meleeDamage);
        }
    }

    void Shoot()
    {
        attackTimer = 0f;
        audioSource.clip = shootSound;
        audioSource.Play();
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shot.isEnemyShot = false;
            shot.direction = mousePosVector - transform.position;
            shot.direction.z = 0f;
            shot.direction.Normalize();
            shot.enabled = true;
        }
    }
}
