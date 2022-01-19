using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using UnityEngine.AI;
public class MiniMapMovement : MonoBehaviour
{
    public Camera FirstPersonCamera;
    public GameObject CameraTarget;
    private Vector3 PrevARPosePosition;

    private float yRotation;

    private bool Tracking = false;

    private float yPosition = 0;
    // Start is called before the first frame update
    public void Awake()
    {
        // Enable ARCore to target 60fps camera capture frame rate on supported devices.
        // Note, Application.targetFrameRate is ignored when QualitySettings.vSyncCount != 0.
        Application.targetFrameRate = 60;
        //FirstPersonCamera.transform.position = new Vector3(SceneDataHandler.myData.startX, 1.17f, SceneDataHandler.myData.startZ);
        //CameraTarget.transform.position = new Vector3(SceneDataHandler.myData.startX, 0, SceneDataHandler.myData.startZ);
        //FirstPersonCamera.transform.position = new Vector3(0, 1.17f, 0);
        //FirstPersonCamera.transform.Rotate(0f, 0f, 0f);

        if (SceneDataHandler.myData.startfloor == 1)
        {
            yPosition = 20;
        }
        //Instantiate(line);
        //line.textureMode = LineTextureMode.Tile;
        //line.GetComponent<LineRenderer>().material = pathMaterial;
        //line.gameObject.layer = 11;

        FirstPersonCamera.transform.position = new Vector3(SceneDataHandler.myData.startX, 1.17f + yPosition, SceneDataHandler.myData.startZ);
        FirstPersonCamera.transform.rotation = Quaternion.Euler(0, SceneDataHandler.myData.startRotation, 0);

        CameraTarget.GetComponent<NavMeshAgent>().enabled = false;
        CameraTarget.transform.position = new Vector3(SceneDataHandler.myData.startX, yPosition, SceneDataHandler.myData.startZ);
        CameraTarget.transform.rotation = Quaternion.Euler(0, SceneDataHandler.myData.startRotation, 0);
        CameraTarget.GetComponent<NavMeshAgent>().enabled = true;
        Debug.Log(transform.position);

    }

    void Start()
    {
        PrevARPosePosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateApplicationLifecycle();
        //move the person indicator according to position
        Vector3 currentARPosition = FirstPersonCamera.transform.position;
        // if (!Tracking)
        // {
        //     Tracking = true;
        //     PrevARPosePosition = FirstPersonCamera.transform.position;
        // }
        // //Remember the previous position so we can apply deltas
        // Vector3 deltaPosition = currentARPosition - PrevARPosePosition;
        // PrevARPosePosition = currentARPosition;
        // if (CameraTarget != null)
        // {
        //     // The initial forward vector of the sphere must be aligned with the initial camera direction in the XZ plane.
        //     // We apply translation only in the XZ plane.
        //     //CameraTarget.transform.Translate(deltaPosition.x, 0.0f, deltaPosition.z);
        //     //CameraTarget.transform.rotation = Quaternion.Euler(0, FirstPersonCamera.transform.eulerAngles.y, 0);
        //     // Set the pose rotation to be used in the CameraFollow script
        //     //FirstPersonCamera.GetComponent<ArrowDirection>().targetRot = Frame.Pose.rotation;
        // }
        CameraTarget.transform.rotation = Quaternion.Euler(0, FirstPersonCamera.transform.eulerAngles.y, 0);
        CameraTarget.transform.position = new Vector3(currentARPosition.x, yPosition, currentARPosition.z);

    }
}
