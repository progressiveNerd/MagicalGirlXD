using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSelectLoad : MonoBehaviour {
	
	private int levelWidth;
	private int levelHeight;
	public Player player;
	public Camera maincam;
	public GameObject Npc1;
	public GameObject Npc2;

	
	//General
	public Transform sidewalk;
	public Transform sidewalkBlock;

	public Transform grassTile;
	public Transform areaSwitch1;

	public Transform brick;
	public Transform schoolSwitch;
	public Transform level2Switch;

	public Transform road;
	public Transform roadLines;
	public Transform roadBlock;
	public Transform roadBlocks;
	private Color[] tileColors;
	
	//General
	public Color playerColor;
	public Color npcColor;

	public Color sidewalkColor;
	public Color sidewalkBlockColor;
	
	public Color grassTileColor;
	public Color areaSwitch1Color;
	
	public Color brickColor;
	public Color schoolSwitchColor;
	public Color level2SwitchColor;


	public Color roadColor;
	public Color roadLinesColor;
	public Color roadBlockColor;
	public Color roadBlocksColor;
	
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
		
		int counter = 0;
		
		for (int y = 0; y < levelHeight; y++) 
		{
			for (int x = 0; x < levelWidth; x++)
			{

				if(tileColors[x+y*levelWidth] == grassTileColor)
				{
					Instantiate(grassTile,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == brickColor)
				{
					Instantiate(brick,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == sidewalkColor)
				{
					Instantiate(sidewalk,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == areaSwitch1Color)
				{
					Instantiate(areaSwitch1,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == schoolSwitchColor)
				{
					Instantiate(schoolSwitch,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == roadColor)
				{
					Instantiate(road,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == roadBlockColor)
				{
					Instantiate(roadBlock,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == roadLinesColor)
				{
					Instantiate(roadLines,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == sidewalkBlockColor)
				{
					Instantiate(sidewalkBlock,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == level2SwitchColor)
				{
					Instantiate(level2Switch,new Vector3(x,y), Quaternion.identity);
				}
			
				else if(tileColors[x+y*levelWidth] == playerColor)
				{
					Instantiate(sidewalk,new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);
					Vector3 posCam = new Vector3(x,y,-10);
					player.transform.position = pos;
					maincam.transform.position = posCam;

				}

				else if (tileColors[x+y*levelWidth] == roadBlocksColor) {
					Instantiate(roadBlocks,new Vector3(x,y), Quaternion.identity);
				}
				else if(tileColors[x+y*levelWidth] == npcColor)
				{
					Instantiate(sidewalk,new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);
					if(counter == 0) {
						Npc1.transform.position = pos;
						counter++;
					}
					else if (counter == 1) {
						Npc2.transform.position = pos;
					}
				}
			}
			
		}
	}
	
}
