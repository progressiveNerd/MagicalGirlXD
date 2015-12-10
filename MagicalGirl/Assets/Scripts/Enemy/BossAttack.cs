using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour
{
    public float range = 150f;
    public Transform shotPrefab;
    public Boss manager;

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
            shot.direction = player.transform.position - transform.position;
            shot.direction.z = 0f;
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
			shot.direction = player.transform.position - transform.position;
			shot.direction.z = 0f;
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
            shot.direction = player.transform.position - transform.position;
            shot.direction.z = 0f;
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
            shot.direction = player.transform.position - transform.position;
            shot.direction.z = 0f;
            shot.direction.Normalize();
        }
    }
}
