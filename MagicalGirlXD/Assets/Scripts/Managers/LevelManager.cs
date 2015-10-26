using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public PointOfInterest[] poi;
    public Transform meleeEnemyPrefab;
    public Transform rangedEnemyPrefab;
    public Transform poiPrefab;
    int deadEnemies;
    Enemy[] enemies;
    GameObject player;
    Transform[] enemyTransforms;
    Transform[] poiTransforms;

	void Start () {
        poi = new PointOfInterest[3];
        /*
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new Enemy[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            enemies[i] = temp[i].GetComponent<Enemy>();
        }
        */
        enemies = new Enemy[3];
        enemyTransforms = new Transform[3];
        poiTransforms = new Transform[3];
        player = GameObject.FindGameObjectWithTag("Player");
        deadEnemies = 0;
        LoadLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void LoadLevel()
    {
        AssignPOIs();
        AssignEnemies();
    }

    void AssignPOIs()
    {
        for (int i = 0; i < 3; i++)
        {
            poiTransforms[i] = Instantiate(poiPrefab) as Transform;
            poiTransforms[i].position = new Vector2(-5+5*i, 5);
            poi[i] = poiTransforms[i].gameObject.GetComponent<PointOfInterest>();
            poi[i].enabled = true;
        }

        poi[0].directionPattern.Add(FacingDirection.Left);
        poi[0].directionPattern.Add(FacingDirection.Right);
        poi[0].restTime = 2;
        poi[0].rotationSpeed = 1;

        poi[1].directionPattern.Add(FacingDirection.Front);
        poi[1].directionPattern.Add(FacingDirection.Back);
        poi[1].directionPattern.Add(FacingDirection.Left);
        poi[1].directionPattern.Add(FacingDirection.Right);
        poi[1].restTime = 4;
        poi[1].rotationSpeed = 0.5f;

        poi[2].directionPattern.Add(FacingDirection.Front);
        poi[2].directionPattern.Add(FacingDirection.Back);
        poi[2].restTime = 2;
        poi[2].rotationSpeed = 1;
    }

    void AssignEnemies()
    {
        for (int i = 0; i < 2; i++)
        {
            enemyTransforms[i] = Instantiate(meleeEnemyPrefab) as Transform;
            enemies[i] = enemyTransforms[i].gameObject.GetComponent<Enemy>();
            enemies[i].enabled = true;
        }

        for (int i = 2; i < 3; i++)
        {
            enemyTransforms[i] = Instantiate(rangedEnemyPrefab) as Transform;
            enemies[i] = enemyTransforms[i].gameObject.GetComponent<Enemy>();
            enemies[i].enabled = true;
        }

        enemyTransforms[0].position = poiTransforms[0].position;
        enemies[0].points.Add(poi[0]);
        enemies[0].points.Add(poi[1]);

        enemyTransforms[1].position = poiTransforms[2].position;
        enemies[1].points.Add(poi[2]);
        enemies[1].points.Add(poi[1]);

        enemyTransforms[2].position = poiTransforms[1].position;
        enemies[2].points.Add(poi[1]);
    }

    void ClearArrays()
    {

    }

    public void EnemyDead()
    {
        deadEnemies++;
        if (deadEnemies == enemies.Length)
            SpawnBoss();
    }

    void SpawnBoss()
    {

    }
}
