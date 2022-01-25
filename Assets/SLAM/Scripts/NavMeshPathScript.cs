using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPathScript : MonoBehaviour
{
    public Transform target;
    public NavMeshPath path;
    //public LineRenderer line;
    public Material pathMaterial;
    private float elapsed = 0.0f;
    public GameObject punkt;
    public Transform tPunkt;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    private Transform targettwo;
    [SerializeField]
    private Transform targetthree;

    private int yPosition = 0;


    private bool doneTargettwo = false;
    private bool doneTargethree = false;


    void Start()
    {
        if (SceneDataHandler.myData.startfloor == 1)
        {
            yPosition = 20;
        }
        //Instantiate(line);
        //line.textureMode = LineTextureMode.Tile;
        //line.GetComponent<LineRenderer>().material = pathMaterial;
        //line.gameObject.layer = 11;

        // player.transform.position = new Vector3(SceneDataHandler.myData.startX, 1.17f + yPosition, SceneDataHandler.myData.startZ);
        // player.transform.Rotate(0, SceneDataHandler.myData.startRotation, 0);

        // Vector3 start = new Vector3(SceneDataHandler.myData.startX, yPosition, SceneDataHandler.myData.startZ);
        // transform.GetComponent<NavMeshAgent>().enabled = false;
        // transform.position = start;
        // //transform.Rotate(0, SceneDataHandler.myData.startRotation, 0);
        // transform.GetComponent<NavMeshAgent>().enabled = true;
        // Debug.Log(transform.position);



        if (SceneDataHandler.myData.startfloor != SceneDataHandler.myData.roomfloor)
        {
            if (SceneDataHandler.myData.startfloor == 0)
            {
                SceneDataHandler.myData.elevatorX = -9;
                SceneDataHandler.myData.elevatorZ = 13;
            }
            else if (SceneDataHandler.myData.startfloor == 1)
            {
                SceneDataHandler.myData.elevatorX = -8;
                SceneDataHandler.myData.elevatorZ = 7;
            }
            target.transform.position = new Vector3(SceneDataHandler.myData.elevatorX, yPosition, SceneDataHandler.myData.elevatorZ);
        }
        else
        {
            target.transform.position = new Vector3(SceneDataHandler.myData.roomX, yPosition, SceneDataHandler.myData.roomZ);
            //target.transform.position = new Vector3(-10, 0, 13.5f);
        }


        this.path = new NavMeshPath();
        elapsed = 0.0f;
        Debug.Log("Start");
        Debug.Log("Target position: " + target.position);
        Debug.Log("Transform position: " + transform.position);
        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        hinlegen();

    }

    void Update()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;

            Debug.Log("my Transform" + transform.position);
            Debug.Log("my Target" + target.position);
            Debug.Log("my Path" + path);
            Debug.Log("my NavMesh" + NavMesh.AllAreas);
        }




        //Line-renderer:
        //line.positionCount = path.corners.Length;
        //line.SetPositions(path.corners);
        //Debug.Log(path.corners.Length);



    }

    void hinlegen()
    {
        Debug.Log("Hinlegen Start");
        Vector2 pathvektor = new Vector2();
        Vector2 normalvektor = new Vector2();

        Debug.Log(path.corners.Length);
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            pathvektor.x = path.corners[i + 1].x - path.corners[i].x;
            pathvektor.y = path.corners[i + 1].z - path.corners[i].z;

            Vector3 hinlegvektor = new Vector3(path.corners[i].x, path.corners[i].y - 0.2f, path.corners[i].z);
            Debug.Log("Hinlegen Vektor" + i + " " + hinlegvektor);
            normalvektor = pathvektor.normalized;
            double length = pathvektor.magnitude;

            for (double z = 0; z < length; z++)
            {
                hinlegvektor.x = hinlegvektor.x + normalvektor.x;
                hinlegvektor.z = hinlegvektor.z + normalvektor.y;
                punkt.layer = 11;
                Instantiate(punkt, hinlegvektor, tPunkt.rotation);
                Debug.Log(punkt);
            }

        }

    }
}