using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linkage : MonoBehaviour
{
    public static NavigationData myData = new NavigationData();


    public void ChangeScene(string sceneName)
    {
        if (sceneName == "IndoorNavigation")
        {
            if (SceneDataHandler.myData.startfloor == 0)
            {
                SceneDataHandler.myData.startfloor = 1;
                SceneDataHandler.myData.startX = -8;
                SceneDataHandler.myData.startZ = 32;
            }
            else if (SceneDataHandler.myData.startfloor == 1)
            {
                SceneDataHandler.myData.startfloor = 0;
                SceneDataHandler.myData.startX = -9;
                SceneDataHandler.myData.startZ = 13;
            }
        }
        Application.LoadLevel(sceneName);
    }
}
