using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerM1 : MonoBehaviour
{
    public static int currentLevel = 1;
    private int fixScore = 0;
    private int finalScore = 0;
    public int roundScore = 0;

    private float timeRemaining = 0.0f;

    public List<TextMeshPro> timeMesh;

    public HandleOperation op1, op2, op3, op4;

    // Start is called before the first frame update
    void Start()
    {
        BuildLevel(currentLevel);

        fixScore = (int)timeRemaining * 2;
        finalScore = 0;
        roundScore = 0;

        op1.BuildOperators();
        op2.BuildOperators();
        op3.BuildOperators();
        op4.BuildOperators();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0.0f)
            timeRemaining -= Time.deltaTime;

        timeMesh[0].text = timeMesh[1].text = ((int)timeRemaining / 60).ToString() + " : " + ((int)timeRemaining - ((int)timeRemaining / 60) * 60).ToString();

        fixScore = (int)timeRemaining * 2;

        finalScore = fixScore + roundScore;

        timeMesh[2].text = "Round: " + finalScore.ToString();

        timeMesh[3].text = "Total Score: " + WorldManager.currentScore.ToString();
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

                timeRemaining = 180.0f;
                break;

            case 2:
                op1.operationType = 1;
                op2.operationType = 1;
                op3.operationType = 1;
                op4.operationType = 2;

                timeRemaining = 180.0f;
                break;

            case 3:
                op1.operationType = 2;
                op2.operationType = 2;
                op3.operationType = 2;
                op4.operationType = 1;

                timeRemaining = 160.0f;
                break;

            case 4:
                op1.operationType = 2;
                op2.operationType = 2;
                op3.operationType = 2;
                op4.operationType = 3;

                timeRemaining = 120.0f;
                break;

            case 5:
                op1.operationType = 2;
                op2.operationType = 2;
                op4.operationType = 3;
                op3.operationType = 3;

                timeRemaining = 120.0f;
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
                if (currentLevel < 5)
                {
                    WorldManager.currentScore += finalScore;

                    currentLevel++;

                    SceneManager.LoadScene("Minigame1");
                }
            }
        }
    }
}
