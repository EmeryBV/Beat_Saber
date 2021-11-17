using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDInfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        if (!XRSettings.isDeviceActive)
        {
            Debug.Log("No Headset plugged");
        }
        
        else if (XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD") || (XRSettings.loadedDeviceName == "MockHMDDisplay"))
        {
            Debug.Log("No Headset plugged");
        }
        
        else
        {
            Debug.Log("HeadSet plug");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}