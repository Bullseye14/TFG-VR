using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerM2 : MonoBehaviour
{
    public int level = 1;

    public HandleTable tableHandler;

    private void Start()
    {
        tableHandler.ProduceNumbers(level);
    }
}