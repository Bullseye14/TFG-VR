using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleOperation : MonoBehaviour
{
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
            // Operation correct
            if (num1.number * num2.number + num3.number == result.operationResult)
            {
                if (!resultShown)
                {
                    indicator.GetComponent<MeshRenderer>().material = indicatorMat[0];

                    resultShown = true;
                }
            }

            // Operation incorrect
            else
            {
                indicator.GetComponent<MeshRenderer>().material = indicatorMat[1];

                resultShown = true;
            }
        }
    }
}
