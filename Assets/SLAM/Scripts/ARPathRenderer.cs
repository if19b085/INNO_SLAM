﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;

public class ARPathRenderer : MonoBehaviour
{
    public LineRenderer ARline;
    public NavMeshPathScript pathScript;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ARline);
        ARline.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ARline.positionCount = pathScript.path.corners.Length;
        ARline.SetPositions(pathScript.path.corners);            
    }
}
