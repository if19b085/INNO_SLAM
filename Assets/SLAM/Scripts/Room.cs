using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    // Start is called before the first frame update
    public string id { get; set; }
    public string description { get; set; }
    public string shortId { get; set; }
    public string building { get; set; }

    public float xCoordinate { get; set; }
    public float zCoordinate { get; set; }
    public int floor { get; set; }

}
