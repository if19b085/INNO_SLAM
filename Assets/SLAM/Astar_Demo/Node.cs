using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldPosition;

    //Coordinates to keep track of position in grid
    public int gridX;
    public int gridY;

    //Distance from interactor 
    public int gCost;
    //Distance to target
    public int hCost;
    //Combined Distance
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public Node parent;


    public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }
}

