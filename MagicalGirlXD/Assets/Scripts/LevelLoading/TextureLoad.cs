using UnityEngine;
using System.Collections;

public class TextureLoad : MonoBehaviour {
	
	private int levelWidth;
	private int levelHeight;
	public Player player;
	public GameObject keyy;

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


	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
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
					player.transform.position = pos;
				}
				else if(tileColors[x+y*levelWidth] == enemyColor || tileColors[x+y*levelWidth] == rangedColor)
				{
					Instantiate(grassTile, new Vector3(x,y), Quaternion.identity);
					//place Point of Interest, Yield return

					//for() {
					//	yield return POI;
					//}
				}
			}
			
		}
	}
	
}
