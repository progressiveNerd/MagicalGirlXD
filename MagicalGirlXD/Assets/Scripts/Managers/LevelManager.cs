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
    public Transform[] enemyTransforms;
    public Transform[] poiTransforms;
	public int deathCounter = 0;
	public GameObject menu;
	private bool isShowing = false;
	private bool hasWon = false;

	void Awake () {
        poi = new PointOfInterest[18];
        poiTransforms = new Transform[18];
        enemies = new Enemy[14];
        enemyTransforms = new Transform[14];
        player = GameObject.FindGameObjectWithTag("Player");
        deadEnemies = 0;
       // LoadLevel();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (!hasWon) {
			if (player.GetComponent<Player>().deathCounter > 10) {
				isShowing = !isShowing;
				menu.SetActive (isShowing);
				hasWon = true;
			}
		}
		*/
	}
    
    void LoadLevel()
    {
        AssignPOIs();
        AssignEnemies();
    }

    public void AssignPOIs()
    {
        for (int i = 0; i < 18; i++)
        {
            poiTransforms[i] = Instantiate(poiPrefab) as Transform;
            poi[i] = poiTransforms[i].gameObject.GetComponent<PointOfInterest>();
            poi[i].enabled = true;
        }

        poi[0].directionPattern.Add(FacingDirection.Left);
        poi[0].directionPattern.Add(FacingDirection.Right);
        poi[0].directionPattern.Add(FacingDirection.Front);
        poi[0].directionPattern.Add(FacingDirection.Back);
        poi[0].restTime = 2;
        poi[0].rotationSpeed = 0.5f;

        poi[1].directionPattern.Add(FacingDirection.Left);
        poi[1].directionPattern.Add(FacingDirection.Right);
        poi[1].directionPattern.Add(FacingDirection.Front);
        poi[1].directionPattern.Add(FacingDirection.Back);
        poi[1].restTime = 2;
        poi[1].rotationSpeed = 0.5f;

        poi[2].directionPattern.Add(FacingDirection.Left);
        poi[2].directionPattern.Add(FacingDirection.Right);
        poi[2].directionPattern.Add(FacingDirection.Front);
        poi[2].directionPattern.Add(FacingDirection.Back);
        poi[2].restTime = 2;
        poi[2].rotationSpeed = 0.5f;

        poi[3].directionPattern.Add(FacingDirection.Left);
        poi[3].directionPattern.Add(FacingDirection.Right);
        poi[3].directionPattern.Add(FacingDirection.Front);
        poi[3].directionPattern.Add(FacingDirection.Back);
        poi[3].restTime = 2;
        poi[3].rotationSpeed = 0.5f;

        poi[4].directionPattern.Add(FacingDirection.Left);
        poi[4].directionPattern.Add(FacingDirection.Right);
        poi[4].directionPattern.Add(FacingDirection.Front);
        poi[4].directionPattern.Add(FacingDirection.Back);
        poi[4].restTime = 2;
        poi[4].rotationSpeed = 0.5f;

        poi[5].directionPattern.Add(FacingDirection.Left);
        poi[5].directionPattern.Add(FacingDirection.Right);
        poi[5].directionPattern.Add(FacingDirection.Front);
        poi[5].directionPattern.Add(FacingDirection.Back);
        poi[5].restTime = 2;
        poi[5].rotationSpeed = 0.5f;

        poi[6].directionPattern.Add(FacingDirection.Left);
        poi[6].directionPattern.Add(FacingDirection.Right);
        poi[6].directionPattern.Add(FacingDirection.Front);
        poi[6].directionPattern.Add(FacingDirection.Back);
        poi[6].restTime = 2;
        poi[6].rotationSpeed = 0.5f;

        poi[7].directionPattern.Add(FacingDirection.Left);
        poi[7].directionPattern.Add(FacingDirection.Right);
        poi[7].directionPattern.Add(FacingDirection.Front);
        poi[7].directionPattern.Add(FacingDirection.Back);
        poi[7].restTime = 2;
        poi[7].rotationSpeed = 0.5f;

        poi[8].directionPattern.Add(FacingDirection.Left);
        poi[8].directionPattern.Add(FacingDirection.Right);
        poi[8].directionPattern.Add(FacingDirection.Front);
        poi[8].directionPattern.Add(FacingDirection.Back);
        poi[8].restTime = 2;
        poi[8].rotationSpeed = 0.5f;

        poi[9].directionPattern.Add(FacingDirection.Left);
        poi[9].directionPattern.Add(FacingDirection.Right);
        poi[9].directionPattern.Add(FacingDirection.Front);
        poi[9].directionPattern.Add(FacingDirection.Back);
        poi[9].restTime = 2;
        poi[9].rotationSpeed = 0.5f;

        poi[10].directionPattern.Add(FacingDirection.Left);
        poi[10].directionPattern.Add(FacingDirection.Right);
        poi[10].directionPattern.Add(FacingDirection.Front);
        poi[10].directionPattern.Add(FacingDirection.Back);
        poi[10].restTime = 2;
        poi[10].rotationSpeed = 0.5f;

        poi[11].directionPattern.Add(FacingDirection.Left);
        poi[11].directionPattern.Add(FacingDirection.Right);
        poi[11].directionPattern.Add(FacingDirection.Front);
        poi[11].directionPattern.Add(FacingDirection.Back);
        poi[11].restTime = 2;
        poi[11].rotationSpeed = 0.5f;

        poi[12].directionPattern.Add(FacingDirection.Left);
        poi[12].directionPattern.Add(FacingDirection.Right);
        poi[12].directionPattern.Add(FacingDirection.Front);
        poi[12].directionPattern.Add(FacingDirection.Back);
        poi[12].restTime = 2;
        poi[12].rotationSpeed = 0.5f;

        poi[13].directionPattern.Add(FacingDirection.Left);
        poi[13].directionPattern.Add(FacingDirection.Right);
        poi[13].directionPattern.Add(FacingDirection.Front);
        poi[13].directionPattern.Add(FacingDirection.Back);
        poi[13].restTime = 2;
        poi[13].rotationSpeed = 0.5f;

        poi[14].directionPattern.Add(FacingDirection.Left);
        poi[14].directionPattern.Add(FacingDirection.Right);
        poi[14].directionPattern.Add(FacingDirection.Front);
        poi[14].directionPattern.Add(FacingDirection.Back);
        poi[14].restTime = 2;
        poi[14].rotationSpeed = 0.5f;

        poi[15].directionPattern.Add(FacingDirection.Left);
        poi[15].directionPattern.Add(FacingDirection.Right);
        poi[15].directionPattern.Add(FacingDirection.Front);
        poi[15].directionPattern.Add(FacingDirection.Back);
        poi[15].restTime = 2;
        poi[15].rotationSpeed = 0.5f;
		poi[15].transform.position = new Vector3 (20, 30);

        poi[16].directionPattern.Add(FacingDirection.Left);
        poi[16].directionPattern.Add(FacingDirection.Right);
        poi[16].directionPattern.Add(FacingDirection.Front);
        poi[16].directionPattern.Add(FacingDirection.Back);
        poi[16].restTime = 2;
        poi[16].rotationSpeed = 0.5f;
		poi[16].transform.position = new Vector3 (30, 20);

        poi[17].directionPattern.Add(FacingDirection.Left);
        poi[17].directionPattern.Add(FacingDirection.Right);
        poi[17].directionPattern.Add(FacingDirection.Front);
        poi[17].directionPattern.Add(FacingDirection.Back);
        poi[17].restTime = 2;
        poi[17].rotationSpeed = 0.5f;
		poi[17].transform.position = new Vector3 (40, 40);

    }

    public void AssignEnemies() {
        System.Random rng = new System.Random();
        for (int i = 0; i < 14; i++) {
            if (rng.NextDouble() > 0.5)
            {
                enemyTransforms[i] = Instantiate(meleeEnemyPrefab) as Transform;
                enemies[i] = enemyTransforms[i].gameObject.GetComponent<Enemy>();
                enemies[i].enabled = true;
                enemies[i].points.Add(poi[rng.Next(18)]);
                enemies[i].points.Add(poi[rng.Next(18)]);
            }
            else
            {
                enemyTransforms[i] = Instantiate(rangedEnemyPrefab) as Transform;
                enemies[i] = enemyTransforms[i].gameObject.GetComponent<Enemy>();
                enemies[i].enabled = true;
                enemies[i].points.Add(poi[rng.Next(18)]);
                enemies[i].ranged = true;
            }
        }
    }

    void ClearArrays() {

    }

    public void EnemyDead() {
        deathCounter++;
        //if (deadEnemies == enemies.Length)
        //    SpawnBoss();
    }
}
