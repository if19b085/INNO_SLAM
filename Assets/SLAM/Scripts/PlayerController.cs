using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public Transform sphere;

    public NavMeshAgent agent;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(sphere.position);
    }
}
