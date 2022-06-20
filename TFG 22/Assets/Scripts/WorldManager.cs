using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public static int currentMinigame = 0;
    public static int currentScore = 0;

    public void GoToMinigame(GameObject minigame)
    {
        string name = minigame.name;

        if(name.Contains("1"))
        {
            currentMinigame = 1;
            SceneManager.LoadScene("Minigame1");
        }

        else if (name.Contains("2"))
        {
            currentMinigame = 2;
            SceneManager.LoadScene("Minigame2");
        }

        else if (name.Contains("3"))
        {
            currentMinigame = 3;
            SceneManager.LoadScene("Minigame3");
        }
    }
    public void AmplifyGO(GameObject GO)
    {
        Vector3 amplifyScale = Vector3.one * 4;
        GO.transform.localScale = amplifyScale;
    }

    public void ReduceGO(GameObject GO)
    {
        Vector3 iniScale = Vector3.one * 2;
        GO.transform.localScale = iniScale;
    }
}
