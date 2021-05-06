using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


public class FullTextSearch : MonoBehaviour
{
    public GameObject Content;
    public Font Font_Of_List_Element;
    public string Search_Term;

    //public Text Search_Term;
    //With Search_Term.text instead of (string)Search_Term in the function

    // Start is called before the first frame update
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

    }

    public void SubmitName(string arg0)
    {
        Search_Term = arg0;

        List<string> list = new List<string>();

        //Create List of Searchable Items (Retrieve from JSON in future
        for (int i = 0; i < 35; i++)
        {
            list.Add("listItem" + i);
        }

        if (!String.IsNullOrEmpty(Search_Term))
        {
            list = list.Where(x => x.Contains(Search_Term)).ToList();
        }

        foreach (string listElement in list)
        {
            //We call a new Game Object named listItem
            GameObject ngo = new GameObject();
            //Now we set the to-be parent object of this Game Object
            ngo.transform.SetParent(Content.transform);
            //By adding a text Component to the new Game Objekt it makes it equivalent to the UI template relative
            Text myText = ngo.AddComponent<Text>();
            //Now we fill this text Component with the wished text
            myText.text = listElement;
            myText.font = Font_Of_List_Element;
            myText.fontStyle = FontStyle.Bold;
            myText.fontSize = 35;
            myText.color = Color.gray;
        }

    }
}
