using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerM1 : MonoBehaviour
{
    public static int currentLevel = 1;

    public HandleOperation op1, op2, op3, op4;

    // Start is called before the first frame update
    void Start()
    {
        BuildLevel(currentLevel);

        op1.BuildOperators();
        op2.BuildOperators();
        op3.BuildOperators();
        op4.BuildOperators();
    }

    private void BuildLevel(int level)
    {
        switch (level)
        {
            case 1:
                op1.operationType = 1;
                op2.operationType = 1;
                op3.operationType = 1;
                op4.operationType = 1;
                break;

            case 2:
                op1.operationType = 1;
                op2.operationType = 1;
                op3.operationType = 2;
                op4.operationType = 2;
                break;

            case 3:
                op1.operationType = 2;
                op2.operationType = 2;
                op3.operationType = 2;
                op4.operationType = 3;
                break;

            case 4:
                op1.operationType = 2;
                op2.operationType = 2;
                op3.operationType = 3;
                op4.operationType = 3;
                break;

            default:
                break;
        }
    }

    public void CheckIfAllCorrect()
    {
        if (currentLevel != 0)
        {
            if (op1.correct && op2.correct && op3.correct && op4.correct)
            {
                if (currentLevel < 4)
                {
                    currentLevel++;

                    SceneManager.LoadScene("Minigame1");
                }
                else if (currentLevel == 4)
                {
                    WorldManager.currentMinigame = 0;
                    WorldManager.currentScore = 0;
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }
}
