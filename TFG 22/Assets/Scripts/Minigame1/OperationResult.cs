using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationResult : MonoBehaviour
{
    public int operationType;

    public int operationResult = 0;

    public List<GameObject> numbersGO;

    public List<GameObject> numbers;

    // Start is called before the first frame update
    void Start()
    {
        // Minimum 0+0+0 = 0, Maximum 9+9+9 = 27 
        if(operationType == 1)
        {
            operationResult = Random.Range(0, 27);
        }

        // Minimum 0*0+0 = 0, Maximum 9*9+9 = 90 
        else if (operationType == 2)
        {
            operationResult = Random.Range(0, 90);
        }

        // Minimum 0*0-9 = -9 but negative numbers are not included, Maximum 9*9-0 = 81 
        else
        {
            operationResult = Random.Range(0, 81);
        }

        // Only 1 digit
        if (operationResult.ToString().Length == 1)
        {
            numbersGO[0] = Instantiate(numbers[0], numbersGO[0].transform);
            numbersGO[1] = Instantiate(numbers[operationResult], numbersGO[1].transform);
        }
        else
        {
            numbersGO[0] = Instantiate(numbers[operationResult/10], numbersGO[0].transform);
            numbersGO[1] = Instantiate(numbers[operationResult%10], numbersGO[1].transform);
        }

    }
}
