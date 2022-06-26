using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerM3 : MonoBehaviour
{
    public float timer = 0f;
    public bool waiting = false;
    public int response = 1;

    public Transform lever;

    public Vector3 leverRot;

    // Update is called once per frame
    void Update()
    {
        leverRot = lever.localRotation.eulerAngles;
        // 213, 180, 147
        if(waiting)
        {
            if (timer <= 10.0f)
            {
                timer += Time.deltaTime;

                // Left
                if (leverRot.z >= 147 && leverRot.z < 165)
                {
                    response = 2;
                }
                // Middle
                else if (leverRot.z >= 165 && leverRot.z <= 195)
                {
                    response = 1;
                }
                // Right
                else if (leverRot.z > 195 && leverRot.z <= 213)
                {
                    response = 0;
                }
            }

            else
            {
                waiting = false;
                timer = 0f;
            }
        }    
    }

    public void MoveLever(int response)
    {
        Vector3 objective = lever.localRotation.eulerAngles;

        switch (response)
        {
            case 0:
                objective.z = 213;
                break;

            case 1:
                objective.z = 180;
                break;

            case 2:
                objective.z = 147;
                break;
        }

        lever.rotation = Quaternion.Lerp(lever.rotation, Quaternion.Euler(objective), Time.deltaTime * 10.0f);
    }
}
