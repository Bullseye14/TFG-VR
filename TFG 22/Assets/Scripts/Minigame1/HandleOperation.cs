using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleOperation : MonoBehaviour
{
    public int operationType;

    // Operation Types
    // Type 1: Number + Number + Number
    // Type 2: Number * Number + Number
    // Type 3: Number * Number - Number

    public OperatorsManager operators;
    public OperationResult result;
    public ColliderCube num1, num2, num3;

    public List<Material> indicatorMat;

    public bool correct = false;
    private bool incorrect = false;

    public GameObject indicator;
    public GameObject lightBulb;

    public ManagerM1 scoreManager;

    public void BuildOperators()
    {
        // A mode de tutorial, farem que un número que pot ser solució
        // aparegui en una de les tres posicions, perque s'entengui que
        // en aquells espais han d'anar-hi números

        result.DetermineOperationResult();

        if (ManagerM1.currentLevel == 1)
            AssignRandomPosition(GetInitialNumber(result.operationResult));

        operators.ChooseCorrectOperators(operationType);
    }

    // We where checking at all times if the operation is correct, we just have to do it when a number changes
    public void CheckOperation()
    {   // All three spaces are filled
        if (num1.numbered && num2.numbered && num3.numbered)
        {
            // We check whether the operation is correct depending on the type of operation
            if (!OperationCorrect(operationType, num1.number, num2.number, num3.number, result.operationResult))
            {
                if (!incorrect)
                {
                    // If it's incorrect, we change the material of the bar to red
                    indicator.GetComponent<MeshRenderer>().material = indicatorMat[1];
                    lightBulb.GetComponent<Light>().color = Color.red;

                    // This makes us not to be changing at all frames the material, only the first time
                    correct = false;
                    incorrect = true;
                }
            }

            if (OperationCorrect(operationType, num1.number, num2.number, num3.number, result.operationResult))
            {
                if (!correct)
                {
                    // If it's correct, we change the material of the bar to green
                    indicator.GetComponent<MeshRenderer>().material = indicatorMat[0];
                    lightBulb.GetComponent<Light>().color = Color.green;

                    // This makes us not to be changing at all frames the material, only the first time
                    correct = true;
                    incorrect = false;

                }
            }
        }
    }

    private bool OperationCorrect(int operationType, int number1, int number2, int number3, int numberResult)
    {
        if (operationType == 1)
        {
            if (number1 + number2 + number3 == numberResult)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        else if (operationType == 2)
        {
            if (number1 * number2 + number3 == numberResult)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        else if (operationType == 3)
        {
            if (number1 * number2 - number3 == numberResult)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        return false;
    }

    private int GetInitialNumber(int result)
    {
        // If the result is 27, the only possible number is 9
        if (result == 27) return 9;

        // If the result is between 19 and 26, we have to increase proportionally the minimum number
        else if (result > 18)
            return Random.Range(result - 18, 9);

        // If the result is between 9 and 18, all numbers are possible
        else if (result > 9)
            return Random.Range(0, 9);

        // If the result is lower than 9, 0 to result are possible answers
        else if (result > 0)
            return Random.Range(0, result);

        // If the result is 0, the only possible number is 0
        else return 0;
    }

    private void AssignRandomPosition(int tutoNumber)
    {
        int position = Random.Range(0, 3);

        switch(position)
        {
            case 0:
                num1.numbered = true;
                num1.PlaceNewNumber(tutoNumber);
                break;

            case 1:
                num2.numbered = true;
                num2.PlaceNewNumber(tutoNumber);
                break;

            case 2:
                num3.numbered = true;
                num3.PlaceNewNumber(tutoNumber);
                break;

            default:
                break;
        }
    }
}
