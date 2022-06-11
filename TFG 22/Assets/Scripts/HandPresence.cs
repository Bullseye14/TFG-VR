using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;

    private bool sceneChanged = false;

    private float timerScene = 0f;

    // Start is called before the first frame update
    void Start()
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
        if (timerScene <= 10f)
            timerScene += Time.deltaTime;
        else
            sceneChanged = false;

        // A de la mà dreta
        //if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        //    Debug.Log("Pressing Primary Button");

        //if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        //    Debug.Log("Trigger pressed " + triggerValue);

        //if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        //    Debug.Log("Primary Touchpad " + primary2DAxisValue);

        // B de la mà dreta
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
        {
            Debug.Log("Pressing Secondary Button");

            if(!sceneChanged && timerScene > 10f)
            {
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);

                sceneChanged = true;
                timerScene = 0f;
            }
        }
    }
}
