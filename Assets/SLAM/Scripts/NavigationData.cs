using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationData : MonoBehaviour
{
    public string roomName { get; set; }
    public string roomDescription { get; set; }

    public float roomX = -20;

    public float roomZ = 11;

    public float startX = -5;
    public float startZ = 0;

    public float startRotation = 0;
    public int startfloor = 0;
    public int roomfloor = 1;
    public float elevatorX { get; set; }
    public float elevatorZ { get; set; }

}
