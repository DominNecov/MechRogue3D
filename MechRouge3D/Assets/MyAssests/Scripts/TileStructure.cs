using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStructure
{
    public bool MainPath = false;
    public bool Empty = true;
    public bool IsStart = false;
    public bool IsEnd = false;
    public string Name;
    public int XLocationInGrid;
    public int YLocationInGrid;
    public GameObject TileToSpawn;

    public TileStructure(string name)
    {
        this.Name = name; 
    }

}
