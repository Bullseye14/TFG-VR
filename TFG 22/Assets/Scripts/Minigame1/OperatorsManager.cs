using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorsManager : MonoBehaviour
{
    public HandleOperation handleOperation;

    public GameObject operator1, operator2;
    public GameObject operator3, operator4;

    public int operationType_ = -1;

    public void ChooseCorrectOperators(int operationType)
    {
        operationType_ = operationType;

        switch (operationType_)
        {
            // + & +
            case 1:
                operator1.gameObject.SetActive(true); operator2.gameObject.SetActive(false);
                operator3.gameObject.SetActive(true); operator4.gameObject.SetActive(false);
                break;
            
            // x & +
            case 2:
                operator1.gameObject.SetActive(false); operator2.gameObject.SetActive(true);
                operator3.gameObject.SetActive(true); operator4.gameObject.SetActive(false);
                break;

            // x & -
            case 3:
                operator1.gameObject.SetActive(false); operator2.gameObject.SetActive(true);
                operator3.gameObject.SetActive(false); operator4.gameObject.SetActive(true);
                break;

            default:
                break;
        }
    }
}
