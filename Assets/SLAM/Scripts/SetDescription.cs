using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDescription : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Name;
    string roomName;
    string description;
    void Start()
    {
        Name.GetComponent<Text>().text = SceneDataHandler.myData.roomName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
