using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linkage : MonoBehaviour
{
    public static NavigationData myData = new NavigationData();


    public void ChangeScene(string sceneName)
    {

        Application.LoadLevel(sceneName);
    }
}
