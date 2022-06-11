using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    public Vector3 respawnPosition;
    private Quaternion respawnRotation = Quaternion.identity;

    private Vector3 intertia_;

    private void Start()
    {
        respawnPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Respawning ball to origin when touching a respawn object
        if(collision.gameObject.tag == "Respawn")
        {
            this.gameObject.transform.position = respawnPosition;

            this.gameObject.transform.rotation = respawnRotation;

            intertia_.x = intertia_.y = intertia_.z = 0.002f;

            // Setting velocity to 0 when respawn
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().inertiaTensor = intertia_;
        }
    }
}
