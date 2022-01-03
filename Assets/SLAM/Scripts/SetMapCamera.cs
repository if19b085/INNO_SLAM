using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMapCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject MapCamera;
    void Start()
    {
        if (SceneDataHandler.myData.startfloor == 0)
        {
            MapCamera.transform.position = new Vector3(-27.65f, 10, 0);
        }
        else if (SceneDataHandler.myData.startfloor == 1)
        {
            MapCamera.transform.position = new Vector3(-27.65f, 30, 0);
        }
    }

}
