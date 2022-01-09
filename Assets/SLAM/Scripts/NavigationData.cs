using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationData : MonoBehaviour
{
    public string roomName { get; set; }
    public string roomDescription { get; set; }

    public float roomX { get; set; }

    public float roomZ { get; set; }

    public float startX { get; set; }
    public float startZ { get; set; }

    public int startfloor { get; set; }
    public int roomfloor { get; set; }

    public float elevatorX { get; set; }
    public float elevatorZ { get; set; }

}
