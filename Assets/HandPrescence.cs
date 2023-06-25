using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPrescence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
       TryInitialize();
    }

    void TryInitialize()
    {
         List<InputDevice> devices = new List<InputDevice>();
        
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        
        //InputDevices.GetDevices(devices);

        foreach (var item in devices){
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0){
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(prefab){
                spawnedController = Instantiate(prefab,transform);
            }
            else{
                Debug.LogError("Modelo de control no encontrado");
                spawnedController = Instantiate(controllerPrefabs[0],transform);
            }
            // spawnedController.SetActive(true);
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            spawnedHandModel.SetActive(false);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }

    }

    void updateHandAnimation ()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else{
            handAnimator.SetFloat("Trigger", 0);
        }
        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else{
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if(showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedController.SetActive(false);
            updateHandAnimation();

        }

        }
        
        
    }
}
