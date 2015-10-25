using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization

    public PointOfInterest[] poi;
    Enemy[] enemies;
    int deadEnemies;
    GameObject player;

	void Start () {
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

    void AssignEnemies()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if(poi.Length % 2 == 0)
            {

            }
            else
            {

            }
        }
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
