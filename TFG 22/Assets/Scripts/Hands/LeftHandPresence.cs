using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class LeftHandPresence : MonoBehaviour
{
    private InputDevice targetDevice;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
            targetDevice = devices[0];
    }

    private void Update()
    {
        // Y per passar a la següent escena (minigame 1 as a test)
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
        {
            if (WorldManager.currentLevel == 0)
                WorldManager.currentLevel = 1;

            SceneManager.LoadScene("Minigame1");
        }
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