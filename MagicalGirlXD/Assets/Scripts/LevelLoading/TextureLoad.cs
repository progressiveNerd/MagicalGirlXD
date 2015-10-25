using UnityEngine;
using System.Collections;

public class TextureLoad : MonoBehaviour {
	
	private int levelWidth;
	private int levelHeight;
	
	public Transform grassTile;
	public Transform stonePath;
	public Transform key;
	public Transform school;
	public Transform soccerGrass;
	public Transform soccerLine;
	public Transform waterTile; 
//	public Transform stairs;
//	public Transform door;

	private Color[] tileColors;
	
	public Color grassColor;
	public Color schoolColor;
	public Color walkwayColor;
	public Color waterColor;
	public Color keyColor;
	public Color areaSwitchColor;
//	public Color doorColor;
	public Color soccerGrassColor;
	public Color soccerLinesColor;
//	public Color stairColor;
	
	public Texture2D levelTexture;
	
	//public Entity player;
	
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
					Debug.Log("Hi");
					Instantiate(stonePath,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == walkwayColor)
				{
					Debug.Log("Hi");
					Instantiate(stonePath,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == waterColor)
				{

					Instantiate(waterTile,new Vector3(x,y), Quaternion.identity);
				}

//				else if(tileColors[x+y*levelWidth] == stairColor)
//				{
//					Instantiate(stairs,new Vector3(x,y), Quaternion.identity);
//				}

				else if(tileColors[x+y*levelWidth] == keyColor)
				{
					Instantiate(key,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == areaSwitchColor)
				{
					Instantiate(stonePath,new Vector3(x,y), Quaternion.identity);
				}

//				else if(tileColors[x+y*levelWidth] == doorColor)
//				{
//					Instantiate(door,new Vector3(x,y), Quaternion.identity);
//				}

				else if(tileColors[x+y*levelWidth] == soccerGrassColor)
				{
					Instantiate(soccerGrass,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == soccerLinesColor)
				{
					Instantiate(soccerLine,new Vector3(x,y), Quaternion.identity);
				}

			}
			
		}
	}
	
}
