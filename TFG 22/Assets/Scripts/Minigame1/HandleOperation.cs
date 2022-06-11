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

    public OperationResult result;
    public ColliderCube num1, num2, num3;

    public int num1_int, num2_int, num3_int, num4_int;

    public List<Material> indicatorMat;

    private bool correct = false;
    private bool incorrect = false;

    public GameObject indicator;

    // Update is called once per frame
    void Update()
    {
        num1_int = num1.number;
        num2_int = num2.number;
        num3_int = num3.number;
        num4_int = result.operationResult;

        // All three spaces are filled
        if (num1.numbered && num2.numbered && num3.numbered)
        {
            // We check whether the operation is correct depending on the type of operation
            if (!OperationCorrect(operationType, num1.number, num2.number, num3.number, result.operationResult))
            {
                if(!incorrect)
                {
                    // If it's incorrect, we change the material of the bar to red
                    indicator.GetComponent<MeshRenderer>().material = indicatorMat[1];

                    // This makes us not to be changing at all frames the material, only the first time
                    correct = false;
                    incorrect = true;
                }
            }

            if (OperationCorrect(operationType, num1.number, num2.number, num3.number, result.operationResult))
            {
                if(!correct)
                {
                    // If it's correct, we change the material of the bar to green
                    indicator.GetComponent<MeshRenderer>().material = indicatorMat[0];

                    // This makes us not to be changing at all frames the material, only the first time
                    correct = true;
                    incorrect = false;

                }
            }
        }
    }

    private bool OperationCorrect(int operationType, int number1, int number2, int number3, int numberResult)
    {
        if(operationType == 1)
        {
            if (number1 + number2 + number3 == numberResult) return true;

            else return false;
        }

        else if (operationType == 2)
        {
            if (number1 * number2 + number3 == numberResult) return true;

            else return false;
        }

        else if (operationType == 3)
        {
            if (number1 * number2 - number3 == numberResult) return true;

            else return false;
        }

        return false;
    }
}
