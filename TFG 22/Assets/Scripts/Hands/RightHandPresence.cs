using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class RightHandPresence : MonoBehaviour
{
    public WorldManager manager;

    public bool showController = false;

    private InputDevice targetDevice;

    public GameObject controllerPrefab;
    public GameObject handPrefab;

    private GameObject spawnedController;
    private GameObject spawnedHand;

    private Animator handAnimator;

    private bool sceneChanged = false;

    private float timerScene = 0f;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();

        manager = GameObject.Find("World Manager").GetComponent<WorldManager>();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

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

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
            TryInitialize();

        else
        {
            //if(showController)
            //{
            //    spawnedHand.SetActive(false);
            //    spawnedController.SetActive(true);
            //}
            //else
            //{
            //    spawnedHand.SetActive(true);
            //    spawnedController.SetActive(false);
            //}

            UpdateHandAnimation();

            if (manager.minigame == 1)
            {
                if (timerScene <= 10f)
                    timerScene += Time.deltaTime;
                else
                    sceneChanged = false;

                // B de la mà dreta per reiniciar l'escena
                if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
                {
                    Debug.Log("Mà dreta: Botó secundari");

                    if (!sceneChanged && timerScene > 10f)
                    {
                        Scene scene = SceneManager.GetActiveScene();
                        SceneManager.LoadScene(scene.name);

                        sceneChanged = true;
                        timerScene = 0f;
                    }
                }
            }
            
            else if (manager.minigame == 3)
            {
                if (manager.m3waiting)
                {
                    if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
                    {
                        if (primary2DAxisValue.x > 0.7)
                            manager.m3response = 2;

                        else if (primary2DAxisValue.x < -0.7)
                            manager.m3response = 0;


                        if (primary2DAxisValue.y > 0.7)
                            manager.m3response = 1;
                    }
                }                    
            }
        }
    }
}

/*

A = primaryButton
B = secondaryButton
Joystick = primary2DAxis (x, y)
Dit índex = trigger (float) // triggerButton
Dit cor = grip (float) // gripButton


Exemples de A, Índex i Joystick:

if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
    Debug.Log("Pressing Primary Button");

if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
    Debug.Log("Trigger pressed " + triggerValue);

if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
    Debug.Log("Primary Touchpad " + primary2DAxisValue);

*/