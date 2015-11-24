﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureLoad : MonoBehaviour {
	
	private int levelWidth;
	private int levelHeight;
	public Player player;
	public GameObject keyy;
	public Camera maincam;
	bool spawnPicked = false;

	Vector3 PlayerTempPos;

	//General
	public Transform stonePath;
	public Transform grassTile;
	public Transform stairs;
	public Transform door;
	public Transform key;
	public Transform areaSwitch;
	public Transform levelSelectSwitch;
	//Fountain
	public Transform waterTile; 
	//use school for brick

	public Transform roadTile;
	public Transform sidewalkTile; 


	//School
	public Transform school;
	public Transform schoolSwitch;
	public Transform schoolDoor;
	public Transform Window;
	public Transform doorFrameSide;
	public Transform doorFrameSide1;
	public Transform schoolFloor;
	public Transform lockerup;
	public Transform lockerDown;
	//Soccer
	public Transform soccerGrass;
	public Transform soccerLine;
	public Transform grassBlock;
	public Transform fence;
	public Transform fence2;
	public Transform bossSwitch;

	private PointOfInterest tempPOI;
	private Enemy tempEnemy;
	private PointOfInterest[] poiList;
	private Enemy[] enemyList;
	private int enemyCounter;
	private int poiCounter;
	Vector2 pos = new Vector2(0,0);
	private Color[] tileColors;

	//General
	public Color roadTileColor;
	public Color sidewalkTileColor; 
	public Color walkwayColor;
	public Color grassColor;
	public Color areaSwitchColor;
	public Color stairsColor;
	public Color doorColor;
	public Color keyColor;
	public Color levelSelectSwitchColor;
	public Color fenceColor;
	//Fountain
	public Color waterColor;
	public Color stoneColor;

	//School
	public Color schoolColor;
	public Color schoolArea;
	public Color schoolDoorColor;
	public Color windowColor;
	public Color doorFrameSideColor;
	public Color lockerColor;
	

	public Color soccersGrassColor;
	public Color soccerLinesColor;

	public Color spawnColor;
	public Color enemyColor; 
	public Color rangedColor;
	public Color grassBlockColor;


	public Color bossSwitchColor;
	
	public Texture2D levelTexture;

	LevelManager lm;


	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		lm = GetComponent<LevelManager> ();
		//lm.LoadLevel(levelTexture.name);
		poiList = lm.AssignPOIs(levelTexture.name);
		enemyList = lm.AssignEnemies(levelTexture.name);
		for (int i = 0; i < enemyList.Length; i++) {
		}
		//Debug.Log (enemyList);
		enemyCounter = 0;
		poiCounter = 0;
		loadLevel ();

	}
	
	void Update () {
		
	}



	void loadLevel()
	{
		spawnPicked = false;
		tileColors = new Color [levelWidth * levelHeight];
		tileColors = levelTexture.GetPixels ();

		int Framecounter = 0;
		int sideCounter = 0;

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

				else if(tileColors[x+y*levelWidth] == levelSelectSwitchColor)
				{
					Instantiate(levelSelectSwitch,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == roadTileColor)
				{
					Instantiate(roadTile,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == sidewalkTileColor)
				{
					Instantiate(sidewalkTile,new Vector3(x,y), Quaternion.identity);
				}
				else if(tileColors[x+y*levelWidth] == lockerColor)
				{
					if(y == 8 || y == 41) {
						Instantiate(lockerDown,new Vector3(x,y), Quaternion.identity);
					}
					else {
						Instantiate(lockerup,new Vector3(x,y), Quaternion.identity);
					}
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
					Instantiate(schoolFloor,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == keyColor)
				{
					if(Application.loadedLevel == 1) {
						Instantiate(waterTile,new Vector3(x,y), Quaternion.identity);
					}
					else if (Application.loadedLevel == 2) {
						Instantiate(soccerLine,new Vector3(x,y), Quaternion.identity);
					}
					else if (Application.loadedLevel == 5) {
						Instantiate(schoolFloor,new Vector3(x,y), Quaternion.identity); 
					}
					Vector2 pos = new Vector2(x,y);
					if(!player.hasWaterKey || !player.hasBossKey || !player.hasSchoolkey)
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
					if(sideCounter < 2 || sideCounter > 4) {
						Instantiate(school,new Vector3(x,y), Quaternion.identity);
						sideCounter++;
					}
					else {
					Instantiate(schoolSwitch,new Vector3(x,y), Quaternion.identity);
						sideCounter++;
					}
				}

				else if(tileColors[x+y*levelWidth] == schoolDoorColor)
				{
					Instantiate(schoolDoor,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == fenceColor)
				{
					if(x <= 10 || x >= 94) {
						Instantiate(fence,new Vector3(x,y), Quaternion.identity);
						Instantiate(sidewalkTile,new Vector3(x,y), Quaternion.identity);
					}
					else {
						Instantiate(fence2,new Vector3(x,y), Quaternion.identity);
						Instantiate(sidewalkTile,new Vector3(x,y), Quaternion.identity);
					}

				}

				else if(tileColors[x+y*levelWidth] == soccersGrassColor)
				{
					Instantiate(soccerGrass,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == grassBlockColor)
				{
					Instantiate(grassBlock,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == soccerLinesColor)
				{
					Instantiate(soccerLine,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == bossSwitchColor)
				{
					Instantiate(bossSwitch,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == windowColor)
				{
					Instantiate(Window,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == doorFrameSideColor)
				{
					if(Framecounter == 0) {
						Framecounter++;
						Instantiate(doorFrameSide,new Vector3(x,y), Quaternion.identity);
					}
					else {
						Instantiate(doorFrameSide1,new Vector3(x,y), Quaternion.identity);
					}
				}


				else if(tileColors[x+y*levelWidth] == spawnColor)
				{

					PlayerTempPos = GameObject.FindWithTag("Preserve").GetComponent<Preserve>().pos;
					if(Application.loadedLevel == 2) {
						Instantiate(grassTile,new Vector3(x,y), Quaternion.identity);

						if(!spawnPicked) {
							if(GameObject.FindWithTag("Preserve").GetComponent<Preserve>().loaded)
							{
								if((PlayerTempPos.x >=14 && PlayerTempPos.x <=24 )&& x == 15) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
								else if((PlayerTempPos.x >=58 && PlayerTempPos.x <=69) && x == 89) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
								else if((PlayerTempPos.x >=100 && PlayerTempPos.x <=120) && x == 52) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}

								else if((PlayerTempPos.x >=23 && PlayerTempPos.x <=26) && x == 52) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
							}

						}


					}
					else if (Application.loadedLevel == 1) {
						Debug.Log(PlayerTempPos);
						Debug.Log(x);
						Instantiate(stonePath,new Vector3(x,y), Quaternion.identity);
						if(!spawnPicked) {
							if(GameObject.FindWithTag("Preserve").GetComponent<Preserve>().loaded) {
								if(PlayerTempPos.y == 0 && x == 41) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
								else if(PlayerTempPos.x >=10 && PlayerTempPos.x <=24 && x == 19) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
								else if(PlayerTempPos.x >=78 && PlayerTempPos.x <=93 && x == 63) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}

								else if(PlayerTempPos.x >= 23 && PlayerTempPos.x <=26 && x == 41 && y >= 30) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
							}
							else {
								pos = new Vector2(41,27);
								spawnPicked = true;
							}
						}
					}
					else if (Application.loadedLevel == 5) {
						Instantiate(schoolFloor,new Vector3(x,y), Quaternion.identity);
						if(!spawnPicked) {
							if(GameObject.FindWithTag("Preserve").GetComponent<Preserve>().loaded) {

								if(PlayerTempPos.x >=40 && PlayerTempPos.x <=42 && x == 24) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
								else if(PlayerTempPos.x >=46 && PlayerTempPos.x <=56 && x == 25) {
									pos = new Vector2(x,y);
									spawnPicked = true;
								}
							}
							else {
								pos = new Vector2(26,41);
								spawnPicked = true;
							}
						}
					}

					Vector3 posCam = new Vector3(x,y,-10);
					player.transform.position = pos;
					maincam.transform.position = posCam;
				}

				else if(tileColors[x+y*levelWidth] == enemyColor || tileColors[x+y*levelWidth] == rangedColor)
				{
					if(Application.loadedLevel != 5)
						Instantiate(grassTile, new Vector3(x,y), Quaternion.identity);
					else
						Instantiate(schoolFloor, new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);

					tempPOI = poiList[poiCounter];
					poiCounter++;
					tempPOI.transform.position = pos;
					tempEnemy = enemyList[enemyCounter];
					enemyCounter++;
					Debug.Log (enemyList[0]);
					tempEnemy.transform.position = pos;
					

				}
			}
			
		}
	}
	
}
