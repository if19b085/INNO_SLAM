using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectRoom : MonoBehaviour
{


    public void setToilletPosition()
    {
        TargetPossition.possition[0] = -53.4f;
        TargetPossition.possition[1] = 7.5f;
        SceneManager.LoadScene("IndoorNavigation");

    }
    public void setElevatorPosition()
    {
        TargetPossition.possition[0] = -10f;
        TargetPossition.possition[1] = 13f;
        SceneManager.LoadScene("IndoorNavigation");
    }

    public void setSmallHallPosition()
    {
        TargetPossition.possition[0] = -22.7f;
        TargetPossition.possition[1] = 2f;
        SceneManager.LoadScene("IndoorNavigation");
    }
    public void setGreatHallPosition()
    {
        TargetPossition.possition[0] = -26.7f;
        TargetPossition.possition[1] = 2f;
        SceneManager.LoadScene("IndoorNavigation");
    }
}
