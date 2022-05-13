using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MagnetBehaviour : MonoBehaviour
{
    public Material newmaterial;

    private InputDevice targetDevice;

    public Transform rightObjective;

    private bool touching = false;

    public bool movingToRight = false;
    private float speed = 7.0f;

    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
            targetDevice = devices[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
                movingToRight = true;
        }

        if (movingToRight)
        {
            transform.LookAt(new Vector3(rightObjective.position.x, rightObjective.position.y, rightObjective.position.z));

            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MagnetRight")
        {
            other.GetComponent<MeshRenderer>().material = newmaterial;

            touching = true;
        }
    }
}
