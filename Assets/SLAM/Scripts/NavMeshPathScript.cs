﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPathScript : MonoBehaviour
{
    public Transform target;
    private NavMeshPath path;
    public LineRenderer line;
    private float elapsed = 0.0f;
    void Start()
    {
        Instantiate(line);
        
        this.path = new NavMeshPath();
        elapsed = 0.0f;
    }

    void Update()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            //Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            
        }
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
        
    }
}