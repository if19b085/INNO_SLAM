using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
public class MiniMapMovement : MonoBehaviour
{
    public Camera FirstPersonCamera;
    public GameObject CameraTarget;
    private Vector3 PrevARPosePosition;
    private bool Tracking = false;
    // Start is called before the first frame update
    public void Awake()
    {
        // Enable ARCore to target 60fps camera capture frame rate on supported devices.
        // Note, Application.targetFrameRate is ignored when QualitySettings.vSyncCount != 0.
        Application.targetFrameRate = 60;
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
        if (!Tracking)
        {
            Tracking = true;
            PrevARPosePosition = FirstPersonCamera.transform.position;
        }
        //Remember the previous position so we can apply deltas
        Vector3 deltaPosition = currentARPosition - PrevARPosePosition;
        PrevARPosePosition = currentARPosition;
        if (CameraTarget != null)
        {
            // The initial forward vector of the sphere must be aligned with the initial camera direction in the XZ plane.
            // We apply translation only in the XZ plane.
            CameraTarget.transform.Translate(deltaPosition.x, 0.0f, deltaPosition.z);
            // Set the pose rotation to be used in the CameraFollow script
            //FirstPersonCamera.GetComponent<ArrowDirection>().targetRot = Frame.Pose.rotation;
        }
    }
}
