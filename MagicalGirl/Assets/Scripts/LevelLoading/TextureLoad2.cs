using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TextureLoad2 : MonoBehaviour
{
	private int levelWidth;
	private int levelHeight;
	public Player player;
	public GameObject keyy;
	public Camera maincam;
	bool spawnPicked = false;
	
	Vector3 PlayerTempPos;
	
	//General
	public Transform grass;
	public Transform grassblock;
	public Transform sidewalk;
	public Transform tree;
	public Transform sidewalkblock;
	public Transform road;
	public Transform sidewalkSwitch1;
	public Transform sidewalkSwitch2;
	public Transform roadLinesHorizontal;
	public Transform car;
	public Transform roadBlock;
	public Transform postOffice;
	public Transform building1, building2;
	public Transform roadblocks;
	public Transform counter;
	public Transform floor;
	public Transform stairs;
	public Transform Wall;

	private PointOfInterest tempPOI;
	private Enemy tempEnemy;
	private PointOfInterest[] poiList;
	private Enemy[] enemyList;
	private int enemyCounter;
	private int poiCounter;
	Vector2 pos = new Vector2(0, 0);
	private Color[] tileColors;
	
	public Color grassColor;
	public Color grassblockColor;
	public Color sidewalkColor;
	public Color treeColor;
	public Color sidewalkblockColor;
	public Color roadColor;
	public Color sidewalkSwitch1Color;
	public Color sidewalkSwitch2Color;
	public Color roadLinesHorizontalColor;
	public Color carColor;
	public Color roadBlockColor;
	public Color postOfficeColor;
	public Color roadblocksColor;
	public Color counterColor;
	public Color floorColor;
	public Color stairsColor;
	public Color spawnColor;
	public Color rangedEnemy;
	public Color meleeEnemy;
	public Color wallColor;
	
	public Texture2D levelTexture;
	
	LevelManager lm;
	
	void Start()
	{
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		lm = GetComponent<LevelManager>();
//		poiList = lm.AssignPOIs(levelTexture.name);
//		enemyList = lm.AssignEnemies(levelTexture.name);
		enemyCounter = 0;
		poiCounter = 0;
		deletePreserve();
		loadLevel();
		
	}
	
	void deletePreserve()
	{
		if (GameObject.FindGameObjectsWithTag("Preserve") != null)
		{
			GameObject[] a = GameObject.FindGameObjectsWithTag("Preserve");
			if (a[0].GetComponent<Preserve>().loaded)
				for (int i = 0; i < a.Length; i++)
					if (!a[i].GetComponent<Preserve>().loaded)
						Destroy(a[i]);
		}
	}
	
	void loadLevel()
	{
		Color currentColor;
		spawnPicked = false;
		tileColors = new Color[levelWidth * levelHeight];
		tileColors = levelTexture.GetPixels();
		bool cameraSet = false;

		int buildingcounter = 0;
		
		for (int y = 0; y < levelHeight; y++)
		{
			for (int x = 0; x < levelWidth; x++)
			{
				currentColor = tileColors[x + y * levelWidth];
				if (currentColor == grassColor)
				{
					Instantiate(grass, new Vector3(x, y), Quaternion.identity);
				}
				
				else if (currentColor == grassblockColor)
					Instantiate(grassblock, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == sidewalkColor)
					Instantiate(sidewalk, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == treeColor)
					Instantiate(tree, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == sidewalkblockColor)
					Instantiate(sidewalkblock, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == roadColor)
				{
						Instantiate(road, new Vector3(x, y), Quaternion.identity);
				}
				
				else if (currentColor == sidewalkSwitch1Color)
					Instantiate(sidewalkSwitch1, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == sidewalkSwitch2Color)
					Instantiate(sidewalkSwitch2, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == roadLinesHorizontalColor)
					Instantiate(roadLinesHorizontal, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == carColor)
					Instantiate(car, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == roadBlockColor)
				{
					Instantiate(roadBlock, new Vector3(x, y), Quaternion.identity);
				}
				
				else if (currentColor == postOfficeColor)
				{
					if(buildingcounter == 0 || buildingcounter == 2 || buildingcounter == 6) {
						Instantiate(grassblock, new Vector3(x, y), Quaternion.identity);
						Instantiate(building1, new Vector3(x, y), Quaternion.identity);
					}
					else if(buildingcounter == 5) {
						Instantiate(postOffice, new Vector3(x, y), Quaternion.identity);
					}
					else {
						Instantiate(building2, new Vector3(x, y), Quaternion.identity);
						Instantiate(grassblock, new Vector3(x, y), Quaternion.identity);
					}
					buildingcounter++;
				}
				
				else if (currentColor == roadblocksColor)
					Instantiate(roadblocks, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == counterColor)
					Instantiate(counter, new Vector3(x, y), Quaternion.identity);
				
				else if (currentColor == floorColor)
				{
						Instantiate(floor, new Vector3(x, y), Quaternion.identity);
				}
				
				else if (currentColor == stairsColor)
					Instantiate(stairs, new Vector3(x, y), Quaternion.identity);
				else if (currentColor == wallColor)
					Instantiate(Wall, new Vector3(x, y), Quaternion.identity);

				else if (currentColor == spawnColor)
				{
					Instantiate(sidewalk, new Vector3(x, y), Quaternion.identity);
					PlayerTempPos = GameObject.FindWithTag("Preserve").GetComponent<Preserve>().pos;


					if (!spawnPicked)
					{
						pos = new Vector2(x, y);
						spawnPicked = true;
					}

					if (spawnPicked && !cameraSet)
					{
						Vector3 posCam = new Vector3(x, y, -10);
						maincam.transform.position = posCam;
						cameraSet = true;
					}
					player.transform.position = pos;
				}
				
				else if (currentColor == meleeEnemy || currentColor == rangedEnemy)
				{
					if (Application.loadedLevel != 5)
						Instantiate(road, new Vector3(x, y), Quaternion.identity);
					else
						Instantiate(road, new Vector3(x, y), Quaternion.identity);


//					Vector2 pos = new Vector2(x, y);
//					tempPOI = poiList[poiCounter];
//					poiCounter++;
//					tempPOI.transform.position = pos;
//					tempEnemy = enemyList[enemyCounter];
//					enemyCounter++;
//					tempEnemy.transform.position = pos;
				}
			}
		}
	}
}

