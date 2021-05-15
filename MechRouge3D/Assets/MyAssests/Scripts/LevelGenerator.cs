using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{
    public TileStructure[,] MapGrid;
    [SerializeField]
    private GameObject openSpacetoSpawn;
    [SerializeField]
    private GameObject openRightSpacetoSpawn;
    [SerializeField]
    private GameObject filledSpacetoSpawn;
    [SerializeField]
    private GameObject heroToSpawn;
    [SerializeField]
    private GameObject enemyToSpawn;
    [SerializeField]
    private GameObject cameraMain;
    [SerializeField]
    private Camera cameraMaincam;
    private List<GameObject> tilesToBake = new List<GameObject>();
    private List<TileStructure> tilesOnMainPath = new List<TileStructure>();
    private List<TileStructure> tilesToBranchFrom = new List<TileStructure>();
    [SerializeField]
    private int gridHeight;
    [SerializeField]
    private int gridWidth;
    private GameObject GO;
    private string tileName;
    private int randomStartNumberX;
    private int randomStartNumberY;
    private int randomEndNumberX;
    private int randomEndNumberY;
    private int xLocationBeingProcessed;
    private int yLocationBeingProcessed;
    private int randomX;
    private int randomY;
    private int endX;
    private int endY;
    private bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        MapGrid = new TileStructure[gridWidth, gridHeight];
        for (int a = 0; a < gridHeight; a++)
        {
            for (int b = 0; b < gridWidth; b++)
            {
                tileName = "tile " + b + a;
                MapGrid[b, a] = new TileStructure(tileName);
                MapGrid[b, a].XLocationInGrid = a;
                MapGrid[b, a].YLocationInGrid = b;
                MapGrid[b, a].TileToSpawn = filledSpacetoSpawn;
            }
        }
        GenerateStartandEnd();
        MakeAPathFromStartToEnd(randomStartNumberY,
                                randomStartNumberX,
                                randomEndNumberY,
                                randomEndNumberX);
        int randomAmountOfBranches = Random.Range(3, 5);
        for(int a = 0; a < randomAmountOfBranches; a++)
        {
            int randomPlaceToBranch = Random.Range(0, tilesOnMainPath.Count);
            tilesToBranchFrom.Add(tilesOnMainPath[randomPlaceToBranch]);
        }
        foreach(TileStructure tilesToBranch in tilesToBranchFrom)
        {
            
            if(up)
            {
               endX = randomEndNumberX - 15;
               endY = randomEndNumberY;
                up = false;
            } else
            {
                endX = randomEndNumberX;
                endY = randomEndNumberY-15;
                up = true;
            }
            Debug.Log(tilesToBranch.YLocationInGrid);
            Debug.Log(tilesToBranch.XLocationInGrid);
            Debug.Log(endY);
            Debug.Log(endX);  
            MakeAPathFromStartToEnd(tilesToBranch.YLocationInGrid,
                                    tilesToBranch.XLocationInGrid,
                                    endY, endX);

        }
        ExpandMainPath(1,1);
        BakeAllWalkableTiles();

        foreach (GameObject surfaceToBake in tilesToBake)
        {
            surfaceToBake.GetComponent<NavMeshSurface>().BuildNavMesh();
        }

        GameObject hero = Instantiate(heroToSpawn, new Vector3(randomStartNumberX * 10 + 1, 1.1f, randomStartNumberY * 10 + 1), Quaternion.identity);
        hero.GetComponent<AimingShootingController>().MainCamera = cameraMaincam;
        hero.name = "Hero";
        cameraMain.GetComponent<CameraMovement>()
            .SetHeroTransform(hero.transform);
        cameraMain.transform.position = hero.transform.position +
            cameraMain.GetComponent<CameraMovement>().offSetVector3;
        Instantiate(enemyToSpawn, new Vector3(randomStartNumberX * 10 + 5, 1, randomStartNumberY * 10 + 5), Quaternion.identity);
    }

    private void BakeAllWalkableTiles()
    {
        for (int a = 0; a < gridHeight; a++)
        {
            for (int b = 0; b < gridWidth; b++)
            {
                Vector3 spawnLocation = new Vector3(10 * a, 0, 10 * b);
                if (MapGrid[b, a].TileToSpawn != null)
                {
                    GO = Instantiate(MapGrid[b, a].TileToSpawn, spawnLocation, Quaternion.identity);
                    if (MapGrid[b, a].TileToSpawn == openSpacetoSpawn)
                    {
                        tilesToBake.Add(GO);
                    }
                }
            }
        }
    }

    private void ExpandMainPath( int minRange,int maxRange )
    {
        foreach (TileStructure tileLocation in tilesOnMainPath)
        {

            int randomNumber = Random.Range(minRange, maxRange);
            for (int a = 1; a <= randomNumber; a++)
            {
                MapGrid[tileLocation.YLocationInGrid + a,
                    tileLocation.XLocationInGrid].TileToSpawn = openSpacetoSpawn;
                MapGrid[tileLocation.YLocationInGrid - a,
                    tileLocation.XLocationInGrid].TileToSpawn = openSpacetoSpawn;
                MapGrid[tileLocation.YLocationInGrid,
                    tileLocation.XLocationInGrid + a].TileToSpawn = openSpacetoSpawn;
                MapGrid[tileLocation.YLocationInGrid,
                    tileLocation.XLocationInGrid - a].TileToSpawn = openSpacetoSpawn;
            }
        }
    }

    private void MakeAPathFromStartToEnd(int startY,int startX, int endY,int endX)
    {
        xLocationBeingProcessed = startX;
        yLocationBeingProcessed = startY;
        while (xLocationBeingProcessed != endX && yLocationBeingProcessed != endY)
        {
            MapGrid[yLocationBeingProcessed, xLocationBeingProcessed].MainPath = true;
            tilesOnMainPath.Add(MapGrid[yLocationBeingProcessed, xLocationBeingProcessed]);
            MapGrid[yLocationBeingProcessed, xLocationBeingProcessed].TileToSpawn = openSpacetoSpawn;
            if (endX == xLocationBeingProcessed)
            {
                randomX = 0;
            }
            else if (endX > xLocationBeingProcessed)
            {
                randomX = 1;
            }
            else if (endX < xLocationBeingProcessed)
            {
                randomX = -1;
            }
            if (endY == yLocationBeingProcessed)
            {
                randomY = 0;
            }
            else if (endY > yLocationBeingProcessed)
            {
                randomY = 1;
            }
            else if (endY < yLocationBeingProcessed)
            {
                randomY = -1;
            }
            xLocationBeingProcessed += randomX;
            yLocationBeingProcessed += randomY;
        }
    }

    private void GenerateStartandEnd()
    {
        randomStartNumberX = Random.Range(3, 10);
        randomStartNumberY = Random.Range(3, 10);
        MapGrid[randomStartNumberY, randomStartNumberX].IsStart = true;
        randomEndNumberX = Random.Range(20, 27);
        randomEndNumberY = Random.Range(20, 27);
    }
}
