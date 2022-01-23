using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static NavigationData myData = new NavigationData();

    //set Room Name and coordinates of selected room in Search Scene
    public void SetStartData()
    {
        if (gameObject.GetComponentInParent<UnityEngine.UI.Text>().text != null)
        {
            myData.roomName = gameObject.GetComponentInParent<UnityEngine.UI.Text>().text;
            SetXAndZCoordinates();

        }
    }

    //set the x and z coordinates of selected room in Search Scene
    private void SetXAndZCoordinates()
    {
        if (FullTextSearch.roomList != null)
        {




            foreach (var element in FullTextSearch.roomList)
            {
                if (myData.roomName == element.id)
                {
                    myData.roomfloor = element.floor;
                    myData.roomX = element.xCoordinate;
                    myData.roomZ = element.zCoordinate;
                    myData.roomDescription = element.description;


                    break;
                }
            }
        }
    }
}
