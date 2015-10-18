using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	public int damagePerShot = 20;
    public int damagePerHit = 30;
	public float attackSpeed = 0.15f;
	public float shootingRange = 100f;
    public float meleeRange = 2f;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	//ParticleSystem gunParticles;
	LineRenderer gunLine;
	//AudioSource gunAudio;
	float effectsDisplayTime = 0.2f;

	void Awake() {
		shootableMask = LayerMask.GetMask("Shootable");
		//gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent<LineRenderer> ();
		//gunAudio = GetComponent<AudioSource> ();
	}

	void Update() {
		timer += Time.deltaTime;
		if(Input.GetButton("Fire1") && timer >= attackSpeed && Time.timeScale != 0)
			Shoot ();
        if (Input.GetButton("Fire2") && timer >= attackSpeed && Time.timeScale != 0)
            Melee();
		if(timer >= attackSpeed * effectsDisplayTime)
			DisableEffects ();
	}

    private void Melee()
    {
        timer = 0f;
        //gunAudio.Play ();
        //gunParticles.Stop ();
        //gunParticles.Play ();

        Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerToMouse = mousePosVector - transform.position;
        playerToMouse.z = 0f;

        shootRay.origin = transform.position;
        shootRay.direction = playerToMouse.normalized;

        if (Physics.Raycast(shootRay, out shootHit, meleeRange, shootableMask))
        {
            Enemy enemy = shootHit.collider.GetComponent<Enemy>();
            if (enemy != null)
                enemy.GetComponent<EnemyHealth>().TakeDamage(damagePerHit, shootHit.point);
        }

    }

	public void DisableEffects() {
		gunLine.enabled = false;
		//gunLight.enabled = false;
	}

	void Shoot() {
		timer = 0f;
		//gunAudio.Play ();
		//gunParticles.Stop ();
		//gunParticles.Play ();
		
		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 playerToMouse = mousePosVector - transform.position;
		playerToMouse.z = 0f;
		
		shootRay.origin = transform.position;
		shootRay.direction = playerToMouse.normalized;
		
		if(Physics.Raycast(shootRay, out shootHit, shootingRange, shootableMask)) {
			Enemy enemy = shootHit.collider.GetComponent<Enemy>();
			if(enemy != null)
				enemy.GetComponent<EnemyHealth>().TakeDamage(damagePerShot, shootHit.point);
			gunLine.SetPosition(1, shootHit.point);
		}
		else
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * shootingRange);
	}
}
