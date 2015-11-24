using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossLoad : MonoBehaviour {

	private int levelWidth;
	private int levelHeight;
	public Player player;
	public GameObject boss;
	public Boss bossScript;

	public Camera maincam;
	public CameraFollow main;


	//General
	public Transform grassTile;
	public Transform lineTile;
	public Transform baseTile;
	public Transform fence;
	public Transform sandTile;

	//School
	public Transform school;
	
	private Color[] tileColors;

	public Color grassColor;
	//School
	public Color schoolColor;
	public Color sandColor;
	public Color lineColor;
	public Color baseColor;

	public Color fenceColor;
	
	public Color spawnColor;
	public Color bossColor; 

	public Vector3 temp;
	
	public Texture2D levelTexture;



	// Use this for initialization
	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		loadLevel ();
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
				
				else if(tileColors[x+y*levelWidth] == sandColor)
				{
					Instantiate(sandTile,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == lineColor)
				{
					Instantiate(lineTile,new Vector3(x,y), Quaternion.identity);
				}
				
				else if(tileColors[x+y*levelWidth] == baseColor)
				{
					Instantiate(baseTile,new Vector3(x,y), Quaternion.identity);
				}

				else if(tileColors[x+y*levelWidth] == fenceColor)
				{
					Instantiate(fence,new Vector3(x,y), Quaternion.identity);
				}

				
				else if(tileColors[x+y*levelWidth] == spawnColor)
				{
					Instantiate(baseTile,new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);
					Vector3 posCam = new Vector3(x,y,-10);
					player.transform.position = pos;
					maincam.transform.position = posCam;
					//temp = posCam;
					
				}
				else if(tileColors[x+y*levelWidth] == bossColor)
				{
					Instantiate(baseTile,new Vector3(x,y), Quaternion.identity);
					Vector2 pos = new Vector2(x,y);
					Vector3 posCam = new Vector3(x,y,-10);
					boss.transform.position = pos;
				}

			}
			
		}
	}
}
