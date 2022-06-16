using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int currentLevel = 0;
    public static int currentScore = 0;

    public HandleOperation op1, op2, op3, op4;

    void Start()
    {
        if (currentLevel != 0)
        {
            BuildLevel(currentLevel);

            op1.BuildOperators();
            op2.BuildOperators();
            op3.BuildOperators();
            op4.BuildOperators();
        }            
    }

    public void CheckIfAllCorrect()
    {
        if(currentLevel != 0)
        {
            if (op1.correct && op2.correct && op3.correct && op4.correct)
            {
                if (currentLevel < 5)
                {
                    currentLevel++;

                    SceneManager.LoadScene("Minigame1");
                }
            }
        }
    }

    private void BuildLevel(int level)
    {
        switch(level)
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
                op3.operationType = 1;
                op4.operationType = 2;
                break;

            case 3:
                op1.operationType = 2;
                op2.operationType = 2;
                op3.operationType = 2;
                op4.operationType = 1;
                break;

            case 4:
                op1.operationType = 2;
                op2.operationType = 2;
                op3.operationType = 2;
                op4.operationType = 3;
                break;

            case 5:
                op1.operationType = 2;
                op2.operationType = 2;
                op4.operationType = 3;
                op3.operationType = 3;
                break;

            default:
                break;
        }
    }
}
