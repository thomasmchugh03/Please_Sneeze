using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileAutomata : MonoBehaviour {


    [Range(0,100)]
    public int iniChance;
    [Range(1,8)]
    public int birthLimit;
    [Range(1,8)]
    public int deathLimit;

    [Range(1,10)]
    public int numR;
    private int count = 0;

    private int[,] terrainMap;
    public Vector3Int tmpSize;
    public Tilemap topMap;
    public Tilemap botMap;
    public RuleTile topTile;
    public Tile botTile;

    public GameObject player;
    public Camera playerCamera;
    private GameObject user;
    private Camera playerCam;

    public GameObject enemy;
    private List<GameObject> enemyList = new List<GameObject>();

    int width;
    int height;


    void Awake()
    {
        
    }

    public void doSim(int nu)
    {
        clearMap(false);
        width = tmpSize.x;
        height = tmpSize.y;

        if (terrainMap==null)
            {
            terrainMap = new int[width, height];
            initPos();
            }


        for (int i = 0; i < nu; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int random = Random.Range(1, 1001);
                if (terrainMap[x, y] == 1)
                {
                    
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                    if(random > 990)
                    {
                        GameObject tmp = Instantiate(enemy, new Vector3(-x + width / 2, -y + height / 2, 0), Quaternion.identity);
                        enemyList.Add(tmp);
                    }
                }
                else
                {
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
                }
                    //topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                    //botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
            }
        }


    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < iniChance ? 1 : 0;
            }

        }

    }


    public int[,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width,height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);
        

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    
                    if (b.x == 0 && b.y == 0)
                    {
                        
                        continue;
                    }
                    if (x+b.x >= 0 && x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighb++;
                    }
                }
                
                if (oldMap[x,y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;

                        else
                        {
                            newMap[x, y] = 1;

                        }
                }

                if (oldMap[x,y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;

                    else
                    {
                        newMap[x, y] = 0;
                    }
                }

            }

        }

        Debug.Log(newMap);



        return newMap;
    }


	void Update () {

        /**
        
        if (Input.GetMouseButtonDown(0))
            {
                //doSim(numR);
                SceneSetup();
            }


        if (Input.GetMouseButtonDown(1))
            {
                clearMap(true);
            }



        if (Input.GetMouseButton(2))
        {
            SaveAssetMap();
            count++;
        }
        
        **/
        }

    public void SceneSetup()
    {
        clearMap(true);
        doSim(numR);
        user = Instantiate(player, new Vector3(-width/2 + 2f, -height/2 + 2f, 0f), Quaternion.identity);
        if(playerCam == null)
        {
            playerCam = Instantiate(playerCamera, new Vector3(-width / 2 + 2f, -height / 2 + 2f, -10f), Quaternion.identity);   
        }
    }


    public void SaveAssetMap()
    {
        string saveName = "tmapXY_" + count;
        var mf = GameObject.Find("Grid");

        if (mf)
        {
            var savePath = "Assets/" + saveName + ".prefab";
            if (PrefabUtility.CreatePrefab(savePath,mf))
            {
                EditorUtility.DisplayDialog("Tilemap saved", "Your Tilemap was saved under" + savePath, "Continue");
            }
            else
            {
                EditorUtility.DisplayDialog("Tilemap NOT saved", "An ERROR occured while trying to saveTilemap under" + savePath, "Continue");
            }


        }


    }

    public void clearMap(bool complete)
    {

        topMap.ClearAllTiles();
        botMap.ClearAllTiles();
        ClearScene();
        if (complete)
        {
            terrainMap = null;
        }


    }

    public void ClearScene()
    {
        Destroy(user);
        Destroy(playerCam);
        foreach(GameObject item in enemyList)
        {
            Destroy(item);
        }
    }



}
