using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour
{
    float speed = 3.0f;

    public Transform target;

    public Vector3 iniPos;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = iniPos;
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            target = other.gameObject.GetComponent<Waypoint>().possibleNextPoint[0];
        }
        else if (other.tag == "QuestionTrigger")
        {

        }
        else if (other.tag == "FinalTrigger")
        {

        }
    }
}
