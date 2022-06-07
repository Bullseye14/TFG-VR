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

    public List<Material> indicatorMat;

    private bool resultShown = false;

    public GameObject indicator;

    // Update is called once per frame
    void Update()
    {
        // All three spaces are filled
        if (num1.numbered && num2.numbered && num3.numbered)
        {
            // We check whether the operation is correct depending on the type of operation
            if (OperationCorrect(operationType, num1.number, num2.number, num3.number, result.operationResult))
            {
                // If it's correct, we change the material of the bar to green
                if (!resultShown)
                {
                    indicator.GetComponent<MeshRenderer>().material = indicatorMat[0];

                    resultShown = true;
                }
            }

            else
            {
                // If it's incorrect, we change the material of the bar to red
                indicator.GetComponent<MeshRenderer>().material = indicatorMat[1];

                resultShown = true;
            }
        }
    }

    private bool OperationCorrect(int operationType, int number1, int number2, int number3, int numberResult)
    {
        bool ret = false;

        // + +
        if (operationType == 1)
            if (number1 + number2 + number3 == numberResult)
                ret = true;

        // x +
        else if (operationType == 2)
            if (number1 * number2 + number3 == numberResult)
                ret = true;

        // x -
        else if (operationType == 3)
            if (number1 * number2 - number3 == numberResult)
                ret = true;

        return ret;
    }
}
