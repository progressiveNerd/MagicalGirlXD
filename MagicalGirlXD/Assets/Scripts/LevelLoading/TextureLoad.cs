using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureLoad : MonoBehaviour {
	
	private int levelWidth;
	private int levelHeight;
	public Player player;
	public GameObject keyy;
	public Camera maincam;

	//General
	public Transform stonePath;
	public Transform grassTile;
	public Transform stairs;
	public Transform door;
	public Transform key;
	public Transform areaSwitch;

	//Fountain
	public Transform waterTile; 
	//use school for brick



	//School
	public Transform school;
	public Transform schoolSwitch;
	public Transform schoolDoor;

	//Soccer
	public Transform soccerGrass;
	public Transform soccerLine;

	private Transform tempPOI;
	private Transform tempEnemy;
	private List<Transform> poiList;
	private List<Transform> enemyList;
	private int enemyCounter = 0;
	private int poiCounter = 0;

	private Color[] tileColors;

	//General

	public Color walkwayColor;
	public Color grassColor;
	public Color areaSwitchColor;
	public Color stairsColor;
	public Color doorColor;
	public Color keyColor;

	//Fountain
	public Color waterColor;
	public Color stoneColor;

	//School
	public Color schoolColor;
	public Color schoolArea;
	public Color schoolDoorColor;
	

	public Color soccersGrassColor;
	public Color soccerLinesColor;

	public Color spawnColor;
	public Color enemyColor; 
	public Color rangedColor;
	
	public Texture2D levelTexture;

	LevelManager lm;


	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		lm = GetComponent<LevelManager> ();
		lm.AssignPOIs ();
		lm.AssignEnemies ();
		poiList = new List<Transform>(lm.poiTransforms);
		enemyList = new List<Transform> (lm.enemyTransforms);
		loadLevel ();

	}
	
	void Update () {
		
	}



	void loadLevel()
	{
		tileColors = new Color [levelWidth * levelHeight];
		tileColors = levelTexture.GetPixels ();



		for (int y = 0; y < levelHeight; y++) 
		{
			for (int x = 0; x < levelWidth; x++)
			{
				if(tileColors[x+y*levelWidth] == grassColor)
				{
					Instantiate(grassTile,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == schoolColor)
				{
					Instantiate(school,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == walkwayColor)
				{
					Instantiate(stonePath,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == areaSwitchColor)
				{
					Instantiate(areaSwitch,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == stairsColor)
				{
					Instantiate(stairs,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == stoneColor)
				{
					Instantiate(school,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == doorColor)
				{
					Instantiate(door,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == keyColor)
				{
					Instantiate(waterTile,new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);
					keyy.transform.position = pos;
				}

				else if(tileColors[x+y*levelWidth] == waterColor)
				{
					Instantiate(waterTile,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == areaSwitchColor)
				{
					Instantiate(areaSwitch,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == schoolArea)
				{
					Instantiate(schoolSwitch,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == schoolDoorColor)
				{
					Instantiate(schoolDoor,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == soccersGrassColor)
				{
					Instantiate(soccerGrass,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == soccerLinesColor)
				{
					Instantiate(soccerLine,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == spawnColor)
				{
					Instantiate(stonePath,new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);
					Vector3 posCam = new Vector3(x,y,-10);
					player.transform.position = pos;
					maincam.transform.position = posCam;


				}
				else if(tileColors[x+y*levelWidth] == enemyColor || tileColors[x+y*levelWidth] == rangedColor)
				{
					Instantiate(grassTile, new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);


					tempPOI = poiList[poiCounter];
					poiCounter++;
					tempPOI.transform.position = pos;

					if(enemyCounter < 14) {
						tempEnemy = enemyList[enemyCounter];
						enemyCounter++;
						tempEnemy.transform.position = pos;
					}

				}
			}
			
		}
	}
	
}
