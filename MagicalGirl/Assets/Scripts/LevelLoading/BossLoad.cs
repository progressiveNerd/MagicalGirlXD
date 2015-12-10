using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossLoad : MonoBehaviour
{
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

    void Start()
    {
        levelWidth = levelTexture.width;
        levelHeight = levelTexture.height;
        loadLevel();
    }


    void loadLevel()
    {
        Color currentColor;
        tileColors = new Color[levelWidth * levelHeight];
        tileColors = levelTexture.GetPixels();

        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                currentColor = tileColors[x + y * levelWidth];
                if (currentColor == grassColor)
                    Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);

                else if (currentColor == schoolColor)
                    Instantiate(school, new Vector3(x, y), Quaternion.identity);

                else if (currentColor == sandColor)
                    Instantiate(sandTile, new Vector3(x, y), Quaternion.identity);

                else if (currentColor == lineColor)
                    Instantiate(lineTile, new Vector3(x, y), Quaternion.identity);

                else if (currentColor == baseColor)
                    Instantiate(baseTile, new Vector3(x, y), Quaternion.identity);

                else if (currentColor == fenceColor)
                    Instantiate(fence, new Vector3(x, y), Quaternion.identity);

                else if (currentColor == spawnColor)
                {
                    Instantiate(baseTile, new Vector3(x, y), Quaternion.identity);
                    Vector2 pos = new Vector2(x, y);
                    Vector3 posCam = new Vector3(x, y, -10);
                    player.transform.position = pos;
                    maincam.transform.position = posCam;
                }

                else if (currentColor == bossColor)
                {
                    Instantiate(baseTile, new Vector3(x, y), Quaternion.identity);
                    Vector2 pos = new Vector2(x, y);
                    Vector3 posCam = new Vector3(x, y, -10);
                    boss.transform.position = pos;
                }
            }
        }
    }
}
