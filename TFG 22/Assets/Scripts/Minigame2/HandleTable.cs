using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleTable : MonoBehaviour
{
    public List<HandleSet> sets;
    public ManagerM2 manager;

    public List<int> naturalNumbers;

    // Levels:
    // 1 --> All numbers are natural (0-9) // 1 tablet
    // 2 --> Natural numbers and decimals (0.0 to 9.9) // 2 tablets
    // 3 --> Natural numbers and decimals (0.0 to 9.9) // 3 tablets
    // 4 --> Natural, decimals and fractions // 3 tablets

    public void ProduceNumbers(int level)
    {
        switch(level)
        {
            case 1:
                OnlyNaturalNumbers();
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            default:
                break;
        }
    }

    // 1 tablet, only natural numbers
    private void OnlyNaturalNumbers()
    {
        for(int i = 0; i < 6; i++)
        {
            int num = Random.Range(0, 10);

            if (naturalNumbers.Count > 0)
            {
                while (naturalNumbers.Contains(num))
                {
                    num = Random.Range(0, 10);
                }
            }

            naturalNumbers.Add(num);
        }

        sets[0].AssignTexts(naturalNumbers);
    }
}
