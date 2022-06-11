using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    public Vector3 cameraInitialPosition;
    public Quaternion cameraInitialRotation;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = cameraInitialPosition;
        this.transform.rotation = cameraInitialRotation;
    }
}
