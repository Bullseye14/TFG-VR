using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WorldManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int currentLevel = 0;
    public static int currentScore = 0;

    public int minigame = 0;

    private int fixScore = 0;
    private int finalScore = 0;
    public int roundScore = 0;

    private float timeRemaining = 0.0f;

    public List<TextMeshPro> timeMesh;

    public HandleOperation op1, op2, op3, op4;

    public float m3timer = 0f;
    public bool m3waiting = false;
    public int m3response = 1;

    void Start()
    {
        if (minigame != 0)
        {
            if (minigame == 1)
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

            else if (minigame == 2)
            {

            }

            else if (minigame == 3)
            {

            }
        }            
    }

    private void Update()
    {
        if (minigame != 0)
        {
            if (minigame == 1)
            {
                if (timeRemaining > 0.0f)
                    timeRemaining -= Time.deltaTime;

                timeMesh[0].text = timeMesh[1].text = ((int)timeRemaining / 60).ToString() + " : " + ((int)timeRemaining - ((int)timeRemaining / 60) * 60).ToString();

                fixScore = (int)timeRemaining * 2;

                finalScore = fixScore + roundScore;

                timeMesh[2].text = "Round: " + finalScore.ToString();

                timeMesh[3].text = "Total Score: " + currentScore.ToString();
            }
            
            else if (minigame == 2)
            {

            }

            else if (minigame == 3)
            {
                if(m3waiting)
                {
                    if (m3timer <= 15.0f)
                        m3timer += Time.deltaTime;

                    else
                    {
                        m3waiting = false;
                        m3timer = 0f;
                    }
                }
            }
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
                    currentScore += finalScore;

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
}
