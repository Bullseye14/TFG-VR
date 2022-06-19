using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerM3 : MonoBehaviour
{
    public float timer = 0f;
    public bool waiting = false;
    public int response = 1;

    // Update is called once per frame
    void Update()
    {
        if(waiting)
        {
            if (timer <= 15.0f)
                timer += Time.deltaTime;

            else
            {
                waiting = false;
                timer = 0f;
            }
        }    
    }
}
