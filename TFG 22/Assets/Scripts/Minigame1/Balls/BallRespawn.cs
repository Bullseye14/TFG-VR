using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public Vector3 respawnPosition;
    private Quaternion respawnRotation = Quaternion.identity;

    private void Start()
    {
        respawnPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            this.gameObject.transform.position = respawnPosition;

            this.gameObject.transform.rotation = respawnRotation;

            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
