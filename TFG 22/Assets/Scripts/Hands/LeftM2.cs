using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class LeftM2 : MonoBehaviour
{
    public bool showController = false;

    private InputDevice targetDevice;

    public GameObject handPrefab;
    private GameObject spawnedHand;

    public ManagerM2 manager;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();

        manager = GameObject.Find("World Manager M2").GetComponent<ManagerM2>();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            spawnedHand = Instantiate(handPrefab, transform);
        }
    }

    private void Update()
    {
        if (!targetDevice.isValid)
            TryInitialize();
    }
}

/*

X = primaryButton
Y = secondaryButton
Joystick = primary2DAxis (x, y)
Dit índex = trigger (float) // triggerButton
Dit cor = grip (float) // gripButton


Exemples de X, Índex i Joystick:

if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
    Debug.Log("Pressing Primary Button");

if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
    Debug.Log("Trigger pressed " + triggerValue);

if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
    Debug.Log("Primary Touchpad " + primary2DAxisValue);

*/