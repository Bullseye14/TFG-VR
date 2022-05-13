using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationResult : MonoBehaviour
{
    public int operationResult = 0;

    public List<GameObject> numbersGO;

    public List<GameObject> numbers;

    // Start is called before the first frame update
    void Start()
    {
        operationResult = Random.Range(0, 90);

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
