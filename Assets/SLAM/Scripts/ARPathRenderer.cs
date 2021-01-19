using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;

public class ARPathRenderer : MonoBehaviour
{
    public LineRenderer ARline;
    public NavMeshPathScript pathScript;
    public ARCameraManager ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ARline);
    }

    // Update is called once per frame
    void Update()
    {
        ARCamera.transform.position = pathScript.path.corners[0];
        ARline.positionCount = pathScript.path.corners.Length;
        ARline.SetPositions(pathScript.path.corners);            
    }
}
