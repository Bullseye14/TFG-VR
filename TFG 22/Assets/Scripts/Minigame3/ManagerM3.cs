using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerM3 : MonoBehaviour
{
    public float timer = 0f;
    public bool waiting = false;
    public int response = 1;

    public int answeredQuestions = -1;
    public int correctQuestions = 0;

    public Transform lever;

    private Vector3 leverRot;

    public List<GameObject> rails;
    public List<Material> railMaterials;

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
                if (leverRot.z >= 147 && leverRot.z < 165 && response != 2)
                {
                    SetResponse(2);
                }
                // Middle
                else if (leverRot.z >= 165 && leverRot.z <= 195 && response != 1)
                {
                    SetResponse(1);
                }
                // Right
                else if (leverRot.z > 195 && leverRot.z <= 213 && response != 0)
                {
                    SetResponse(0);
                }
            }

            else
            {
                waiting = false;
                timer = 0f;
            }
        }    
    }

    private void SetResponse(int leverPos)
    {
        response = leverPos;

        for(int i = 0; i < rails.Count; i++)
        {
            rails[i].GetComponent<MeshRenderer>().material = railMaterials[0];
        }

        switch(leverPos)
        {
            case 2:
                rails[3].GetComponent<MeshRenderer>().material = railMaterials[1];
                rails[4].GetComponent<MeshRenderer>().material = railMaterials[1];
                break;

            case 1:
                rails[2].GetComponent<MeshRenderer>().material = railMaterials[1];
                break;

            case 0:
                rails[0].GetComponent<MeshRenderer>().material = railMaterials[1];
                rails[1].GetComponent<MeshRenderer>().material = railMaterials[1];
                break;

            default:
                break;
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
