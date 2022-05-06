using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using System.Linq;



//DO NOT USE THIS SCRIPT

//USE PLAYER CONTROLS SCRIPT INSTEAD





public class PlayerSheetScript : MonoBehaviour
{
    public GameObject playerSheet;


    [System.Serializable]
    public class Callback : UnityEvent<Ray, RaycastHit> { }
    [SerializeField]
    private XRNode xrNodeL = XRNode.LeftHand;
    private XRNode xrNodeR = XRNode.RightHand;
    private InputDeviceRole inputDevice;
    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;

    public Transform leftHandAnchor = null;
    public Transform rightHandAnchor = null;
    public Transform centerEyeAnchor = null;
    public float maxRayDistance = 500;
    public LayerMask excludeLayers;
    public GameObject xrRig;

    bool secondaryButton;
    bool isSheetActive = false;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNodeL, devices);
        InputDevices.GetDevicesAtXRNode(xrNodeR, devices);
        device = devices.FirstOrDefault();
    }

    void Start()
    {
        playerSheet = GameObject.FindGameObjectWithTag("PlayerSheet");
    }

    // Update is called once per frame
    void Update()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        //Controlling Character Sheet
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButton) && secondaryButton)
        {
            if (!isSheetActive)
            {
                StartCoroutine("ActivateCharacterSheet");
            }
            else
            {
                StartCoroutine("DeactivateCharacterSheet");
            }
        }
    }

    //Character Sheet On
    IEnumerator ActivateCharacterSheet()
    {
        playerSheet.SetActive(true);
        yield return new WaitForSeconds(1f);
        isSheetActive = true;
    }
    //Character Sheet Off
    IEnumerator DeactivateCharacterSheet()
    {
        playerSheet.SetActive(false);
        yield return new WaitForSeconds(1f);
        isSheetActive = false;
    }
}
