using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;



public class FullTextSearch : MonoBehaviour
{
    public GameObject ListElementPrefab;
    public GameObject Content;
    public string Search_Term;
    public static List<Room> roomList = new List<Room>();
    List<Room> displayList;
    private Room roomy;
    private InputField input;

    //public Text Search_Term;
    //With Search_Term.text instead of (string)Search_Term in the function

    // Start is called before the first frame update
    void Start()
    {
        JsonParse();
        input = gameObject.GetComponent<InputField>();
        input.onValueChanged.AddListener(delegate { SubmitName(); });
    }

    public void SubmitName()
    {

        foreach (Transform child in Content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        Search_Term = input.text;


        if (!String.IsNullOrEmpty(Search_Term))
        {
            displayList = roomList.Where(x => x.id.ToLower().Contains(Search_Term.ToLower())).ToList();
        }

        foreach (Room listElement in displayList)
        {
            ListElementPrefab.GetComponent<UnityEngine.UI.Text>().text = listElement.id;
            Instantiate(ListElementPrefab, Content.transform);
        }
    }

    public void JsonParse()
    {
        string jsonString = File.ReadAllText("Assets/SLAM/JSON/fhtwroomsF_E.json");
        JObject data = JObject.Parse(jsonString);
        string roomArray = data["roomDescriptions"].ToString();
        JArray jArray = JArray.Parse(roomArray);
        foreach (JObject jObject in jArray)
        {
            roomy = new Room();
            roomy.id = jObject["id"].ToString();
            roomy.description = jObject["description"].ToString();
            roomy.shortId = jObject["shortId"].ToString();
            roomy.building = jObject["building"].ToString();
            roomy.xCoordinate = float.Parse(jObject["x"].ToString());
            roomy.zCoordinate = float.Parse(jObject["z"].ToString());
            roomList.Add(roomy);
        }
    }


}

/*public class Room
{
    public string id { get; set; }
    public string description { get; set; }
    public string shortId { get; set; }
    public string building { get; set; }
}*/
