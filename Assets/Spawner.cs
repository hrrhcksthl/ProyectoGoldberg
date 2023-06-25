/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    private InputDevice targetDevice;
    public GameObject instanceObject;
    bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if(devices.Count > 0){
            targetDevice = devices[0];
        }        
    }

    // Update is called once per frame
void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if(triggerValue > 0.1f){ // REVISAR EL IF, EL SPAWN DE PELOTAS SI FUNCIONA, EL SPAWN FUNCIONA EN GENERAL
            isPressed = !isPressed;
        }

        if(isPressed){
            Debug.Log("Trigger click");
            SpawnIt();
        }
    }

    void SpawnIt(){
        Instantiate(instanceObject, transform.position, Quaternion.identity);
    }
}
*/