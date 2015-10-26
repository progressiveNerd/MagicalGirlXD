using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	public int damagePerShot = 1;
    public int damagePerHit = 2;
	public float attackSpeed = 0.15f;
	public float shootingRange = 100f;
    public float meleeRange = 2f;
    public AudioClip meleeSound, shootSound;
	public Transform shotPrefab;

	float attackTimer;
	int shootableMask;
    AudioSource Audio;
    Ray shootRay;
    RaycastHit shootHit;

	void Awake() {
		shootableMask = LayerMask.GetMask("Shootable");
        Audio = GetComponent<AudioSource>();
	}

	void Update() {
		attackTimer += Time.deltaTime;
		if(Input.GetButton("Fire1") && attackTimer >= attackSpeed && Time.timeScale != 0)
			Shoot();
        if (Input.GetButton("Fire2") && attackTimer >= attackSpeed && Time.timeScale != 0)
            Melee();
	}

    private void Melee() {
        attackTimer = 0f;
        Audio.clip = meleeSound;
        Audio.Play();

        Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouse = mousePosVector - transform.position;
        playerToMouse.z = 0f;

        shootRay.origin = transform.position;
        shootRay.direction = playerToMouse.normalized;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, playerToMouse.normalized, meleeRange, shootableMask);
        if (hit.collider != null) {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damagePerHit);
        }
    }

	void Shoot() {
		attackTimer = 0f;
        Audio.clip = shootSound;
        Audio.Play();
		var shotTransform = Instantiate(shotPrefab) as Transform;
		shotTransform.position = transform.position;
		ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null) {
            Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shot.isEnemyShot = false;
            shot.direction = mousePosVector - transform.position;
            shot.direction.z = 0f;
            shot.direction.Normalize();
            shot.enabled = true;
        }
		//gunParticles.Stop();
		//gunParticles.Play();

		/*
		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 playerToMouse = mousePosVector - transform.position;
		playerToMouse.z = 0f;

		shootRay.origin = transform.position;
		shootRay.direction = playerToMouse.normalized;

		Debug.Log(shootRay.origin.ToString());
		
		if(Physics.Raycast(shootRay, out shootHit, shootingRange, shootableMask)) {
			Debug.Log("Shot");
			Enemy enemy = shootHit.collider.GetComponent<Enemy>();
			if(enemy != null)
				enemy.GetComponent<EnemyHealth>().TakeDamage(damagePerShot, shootHit.point);
			gunLine.SetPosition(1, shootHit.point);
		}
		else
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * shootingRange);
		*/
	}
}
