using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour
{
    public ManagerM3 manager;

    float speed = 3.0f;

    public Transform target;

    public Vector3 iniPos;

    public ChooseQuestion chooseScript;

    public bool moving = true;

    public List<Transform> targets;

    private bool touchedQuestion = false;

    public ChooseQuestion questions;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = iniPos;
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
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

            this.transform.position = iniPos;

            questions.GetNewQuestion();
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
