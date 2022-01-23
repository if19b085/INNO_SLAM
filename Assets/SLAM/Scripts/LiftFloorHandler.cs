using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftFloorHandler : MonoBehaviour
{

    public Text text;


    void Start()
    {
        text.text = "Go to the " + SceneDataHandler.myData.roomfloor.ToString() +". floor";
    }

   
}
