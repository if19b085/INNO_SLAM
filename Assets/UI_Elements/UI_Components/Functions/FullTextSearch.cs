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
    public GameObject Content;
    public Font Font_Of_List_Element;
    public string Search_Term;
    private List<string> list = new List<string>();
    private List<Room> roomList = new List<Room>();
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
        //var se = new InputField.SubmitEvent();
        //se.AddListener(SubmitName);
        //input.onEndEdit = se;

    }
     
    public void SubmitName()
    {
        JsonParse();
        Search_Term = input.text;


        //Create List of Searchable Items 
        //Application.dataPath to relatively search file
        


        if (!String.IsNullOrEmpty(Search_Term))
        {
            roomList = roomList.Where(x => x.id.ToLower().Contains(Search_Term.ToLower())).ToList();
        }

        foreach (Room listElement in roomList)
        {
            //We call a new Game Object named listItem
            GameObject ngo = new GameObject();
            //Now we set the to-be parent object of this Game Object
            //Prefabs generieren und eine Liste von GameObject zu erstellen -> über OnValueChange(look at instantiate)
            ngo.transform.SetParent(Content.transform);
            //By adding a text Component to the new Game Objekt it makes it equivalent to the UI template relative
            Text myText = ngo.AddComponent<Text>();
            //Now we fill this text Component with the wished text
            myText.text = listElement.id;
            myText.font = Font_Of_List_Element;
            myText.fontStyle = FontStyle.Bold;
            myText.fontSize = 35;
            myText.color = Color.gray;
        }

    }

    public void JsonParse()
    {
        string jsonString = File.ReadAllText("Assets/UI_Elements/UI_Components/JSON/fhtwrooms.json");
        JObject data = JObject.Parse(jsonString);
        string roomArray = data["roomDescriptions"].ToString();
        JArray jArray = JArray.Parse(roomArray);
        foreach(JObject jObject in jArray)
        {
            roomy = new Room();
            roomy.id = jObject["id"].ToString();
            roomy.description = jObject["description"].ToString();
            roomy.shortId = jObject["shortId"].ToString();
            roomy.building = jObject["building"].ToString();
            roomList.Add(roomy);
        }
    }

    
 }

public class Room
{
    public string id { get; set; }
    public string description { get; set; }
    public string shortId { get; set; }
    public string building { get; set; }
}
