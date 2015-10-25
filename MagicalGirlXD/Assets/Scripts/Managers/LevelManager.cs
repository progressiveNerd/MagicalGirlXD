using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization

    public PointOfInterest[] poi;
    Enemy[] enemies;
    int deadEnemies;
    GameObject player;

	void Start () {
        poi = new PointOfInterest[3];
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new Enemy[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            enemies[i] = temp[i].GetComponent<Enemy>();
        }
        player = GameObject.FindGameObjectWithTag("Player");
        deadEnemies = 0;
        LoadLevel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void LoadLevel()
    {
       
    }

    void CreatePOIs()
    {
        poi[0].left = true;
        poi[0].right = true;
        poi[0].restTime = 2;
        poi[0].rotationSpeed = 1;
    }

    void AssignEnemies()
    {
        enemies[0].points.Add(poi[0]);
        enemies[0].points.Add(poi[1]);

        enemies[1].points.Add(poi[2]);
        enemies[1].points.Add(poi[1]);

        enemies[2].points.Add(poi[1]);
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
