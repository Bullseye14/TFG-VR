using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour
{
    public ManagerM3 manager;

    public ChooseQuestion chooseScript;

    public Light farolet;
    public GameObject faroletGO;

    float speed = 3.0f;

    public Transform target;

    public Vector3 iniPos;
    public Quaternion iniRotation;

    public bool moving = true;

    public List<Transform> targets;
    public List<Material> materials;

    private bool touchedQuestion = false;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        this.transform.position = iniPos;
        this.transform.rotation = iniRotation;
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

        farolet.color = Color.blue;
        faroletGO.GetComponent<MeshRenderer>().material = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(!moving)
        {
            if(!manager.waiting)
            {
                target = targets[manager.response];
                moving = true;
            }
        }

        else if (moving)
            Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            target = other.gameObject.GetComponent<Waypoint>().possibleNextPoint[0];
        }
        else if (other.tag == "QuestionTrigger")
        {
            if(!touchedQuestion)
            {
                moving = false;
                manager.waiting = true;

                touchedQuestion = true;
            }
        }
        else if (other.tag == "FinalTrigger")
        {
            touchedQuestion = false;

            Spawn();

            chooseScript.GetNewQuestion();
        }
        else if(other.tag == "Test")
        {
            if(other.name == "Correct Answer")
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }

    private void CorrectAnswer()
    {
        farolet.color = Color.green;
        faroletGO.GetComponent<MeshRenderer>().material = materials[1];
    }

    private void WrongAnswer()
    {
        farolet.color = Color.red;
        faroletGO.GetComponent<MeshRenderer>().material = materials[2];
    }
}
