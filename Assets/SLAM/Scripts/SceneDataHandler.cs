using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static NavigationData myData = new NavigationData();

    public void SetStartData()
    {
        if (gameObject.GetComponentInParent<UnityEngine.UI.Text>().text != null)
        {
            myData.roomName = gameObject.GetComponentInParent<UnityEngine.UI.Text>().text;
        }
    }
}
