using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class LeftM3 : MonoBehaviour
{
    public bool showController = false;

    private InputDevice targetDevice;

    public GameObject controllerPrefab;
    public GameObject handPrefab;

    private GameObject spawnedController;
    private GameObject spawnedHand;

    private Animator handAnimator;

    public ManagerM3 manager;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();

        manager = GameObject.Find("World Manager M3").GetComponent<ManagerM3>();
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

            if (controllerPrefab)
                spawnedController = Instantiate(controllerPrefab, transform);
            else
                Debug.Log("Couldn't find controller model");

            spawnedHand = Instantiate(handPrefab, transform);
            handAnimator = spawnedHand.GetComponent<Animator>();

            spawnedController.SetActive(false);
        }
    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            handAnimator.SetFloat("Trigger", triggerValue);

        else
            handAnimator.SetFloat("Trigger", 0);

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            handAnimator.SetFloat("Grip", gripValue);

        else
            handAnimator.SetFloat("Grip", 0);
    }

    private void Update()
    {
        if (!targetDevice.isValid)
            TryInitialize();

        else
            UpdateHandAnimation();
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