using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    PointOfInterest[] poi;
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

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deadEnemies = 0;
        // LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
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

    void LoadLevel(string level)
    {
        AssignPOIs(level);
        AssignEnemies(level);
    }

    public void AssignPOIs(string level)
    {
        CSVReader csv = new CSVReader("Assets/CSVs/" + level + "/poi.csv");
        List<string[]> level_pois = csv.Read();

        poi = new PointOfInterest[level_pois.Count];
        poiTransforms = new Transform[level_pois.Count];

        for (int i = 0; i < level_pois.Count; i++) //initialize all pois
        {
            poiTransforms[i] = Instantiate(poiPrefab) as Transform;
            poi[i] = poiTransforms[i].gameObject.GetComponent<PointOfInterest>();
            poi[i].enabled = true;
        }

        for (int i = 0; i < level_pois.Count; i++) //initialize all pois
        {
            for (int j = 0; j < level_pois[i].Length; j++)
            {
                Debug.Log(level_pois[i][j]);
                if (level_pois[i][j] == "front")
                {
                    poi[i].directionPattern.Add(FacingDirection.Front); //add direction patterns
                }
                else if (level_pois[i][j] == "back")
                {
                    poi[i].directionPattern.Add(FacingDirection.Back);
                }
                else if (level_pois[i][j] == "right")
                {
                    poi[i].directionPattern.Add(FacingDirection.Right);
                }
                else if (level_pois[i][j] == "left")
                {
                    poi[i].directionPattern.Add(FacingDirection.Left);
                }
                else if (j == level_pois[i].Length - 2) //second to last item is wait time at poi
                {
                    poi[i].restTime = float.Parse(level_pois[i][j]);
                }
                else if (j == level_pois[i].Length - 1) //last item in line is rotation speed
                {
                    poi[i].rotationSpeed = float.Parse(level_pois[i][j]);
                }
            }
        }
    }

    public void AssignEnemies(string level)
    {
        CSVReader csv = new CSVReader("Assets/CSVs/" + level + "/enemy.csv");
        List<string[]> level_enemies = csv.Read();

        enemies = new Enemy[level_enemies.Count];
        enemyTransforms = new Transform[level_enemies.Count];

        for (int i = 0; i < level_enemies.Count; i++) //initialize all pois
        {
            if (level_enemies[i][0] == "ranged")
            {
                poiTransforms[i] = Instantiate(rangedEnemyPrefab) as Transform;
            }
            else
            {
                poiTransforms[i] = Instantiate(meleeEnemyPrefab) as Transform;
            }
            enemies[i] = poiTransforms[i].gameObject.GetComponent<Enemy>();
            enemies[i].enabled = true;
        }

        int t;
        for (int i = 0; i < level_enemies.Count; i++) //initialize all pois
        {
            for (int j = 0; j < level_enemies[i].Length; j++)
            {
                Debug.Log(level_enemies[i][j]);
                if (int.TryParse(level_enemies[i][j], out t))
                {
                    enemies[i].points.Add(poi[t]);
                }
            }
        }
    }

    void ClearArrays()
    {

    }

    public void EnemyDead()
    {
        deathCounter++;
        //if (deadEnemies == enemies.Length)
        //    SpawnBoss();
    }
}
