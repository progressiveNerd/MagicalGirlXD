using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour
{
    public float range = 150f;
    public Transform shotPrefab;
    public Boss manager;
	public Boss2 manager2;

    int attackDirection = 1;

	void Update() {

	}

    public void Attack(GameObject player)
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = true;
            shot.direction = new Vector3(attackDirection * Mathf.Cos(2 * Time.time), -1* Mathf.Abs(Mathf.Sin(3 * Time.time)), 0f);
            attackDirection *= -1;
            shot.direction.Normalize();
        }
    }

    public void SpecialAttack1(GameObject player)
    {
		var shotTransform = Instantiate(shotPrefab) as Transform;
		shotTransform.position = transform.position;
		ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			shot.isEnemyShot = true;
            shot.direction = new Vector3(Mathf.Abs(Mathf.Cos(Time.time)), Mathf.Sin(5 * Time.time), 0f);
            //shot.direction = player.transform.position - transform.position;
            //shot.direction.z = 0f;
			shot.direction.Normalize();
		}
	

    }

    public void SpecialAttack2(GameObject player)
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = true;
            shot.direction = new Vector3(attackDirection * Mathf.Abs(Mathf.Cos(5 * Time.time)), Mathf.Sin(5 * Time.time), 0f);
            attackDirection *= -1;
            shot.direction.Normalize();
        }
    }

    public void SpecialAttack3(GameObject player)
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = true;
            shot.direction = new Vector3(-1*Mathf.Abs(Mathf.Cos(Time.time)), Mathf.Sin(5 * Time.time), 0f);
            shot.direction.Normalize();
        }
    }
}
