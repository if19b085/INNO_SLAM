using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InElevator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string NewScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(NewScene);
            //Application.LoadLevel(NewScene);
        }
    }
}
