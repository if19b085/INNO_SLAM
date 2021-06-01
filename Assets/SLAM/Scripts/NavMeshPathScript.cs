using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPathScript : MonoBehaviour
{
    public Transform target;
    public NavMeshPath path;
    public LineRenderer line;
    public Material pathMaterial;
    private float elapsed = 0.0f;
    public GameObject punkt;
    public Vector3 hinlegerVektor;
    void Start()
    {              
        Instantiate(line);
        line.textureMode = LineTextureMode.Tile;
        line.GetComponent<LineRenderer>().material = pathMaterial;
        this.path = new NavMeshPath();
        elapsed = 0.0f;
        line.gameObject.layer = 11;
        target.position = new Vector3(TargetPossition.possition[0], target.position.y, TargetPossition.possition[1]);
        Debug.Log("Start");
        Debug.Log(target.position);


        hinlegerVektor = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log(hinlegerVektor);
    }

    void Update()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f)
        {
            elapsed -= 1.0f;
            
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
            hinlegen();
        }
        
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
        Debug.Log(path.corners.Length);

        
                     
    }

    void hinlegen()
    {
        
        for (int i = 0; i <= path.corners.Length-1; i++)
        {
            Debug.Log(path.corners[i]);
            while (hinlegerVektor.x + 2 < path.corners[i].x)
            {
                hinlegerVektor.x = hinlegerVektor.x + 2f;
                Instantiate(punkt, hinlegerVektor, target.rotation);
            }

            while (hinlegerVektor.z + 2 < path.corners[i].z)
            {

                hinlegerVektor.z = hinlegerVektor.z + 2f;
                Instantiate(punkt, hinlegerVektor, target.rotation);
            }

            while (hinlegerVektor.x - 2 > path.corners[i].x)
            {
                hinlegerVektor.x = hinlegerVektor.x - 2f;
                Instantiate(punkt, hinlegerVektor, target.rotation);
            }

            while (hinlegerVektor.z - 2 > path.corners[i].z)
            {
                hinlegerVektor.z = hinlegerVektor.z - 2f;
                Instantiate(punkt, hinlegerVektor, target.rotation);
            }
        }
    }
}