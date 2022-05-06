using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using System.Linq;

public class GMControls : MonoBehaviour
{
    public GameObject GMSheet;
    public enum PlayerState
    {
        OnBoard,
        InRoom
    }
    public PlayerState state;

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
    // Start is called before the first frame update
    void Start()
    {
        state = PlayerState.InRoom;
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
                StartCoroutine("ActivateGMSheet");
            }
            else
            {
                StartCoroutine("DeactivateGMSheet");
            }
        }

        //Ray ray = new Ray(leftHandAnchor.position, Vector3.forward);
        //RaycastHit hit;

        //if(Physics.Raycast(ray, out hit, maxRayDistance, ~excludeLayers))
        //{
        //    if(hit.transform.gameObject.tag == "Enemy")
        //    {
        //        if(device.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButton) && secondaryButton)
        //        {
        //            Destroy(hit.transform.gameObject);
        //        }
        //    }
        //}
    }

    //GM Sheet On
    IEnumerator ActivateGMSheet()
    {
        if (GMSheet == null)
        {
            GMSheet = Instantiate(Resources.Load("NewGMCanvas")) as GameObject;
            //GMSheet.transform.SetParent(this.transform.GetChild(0));
            //yield return new WaitForSeconds(1f);
            GMSheet.transform.SetParent(this.transform.GetChild(0).transform.GetChild(2));
            GMSheet.transform.localPosition = new Vector3(0f, .4f, 0.2f);
            GMSheet.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            GMSheet.transform.localScale = new Vector3(.0025f, .0025f, 1f);
        }
        else if (GMSheet != null)
        {
            GMSheet.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        isSheetActive = true;
    }
    //GM Sheet Off
    IEnumerator DeactivateGMSheet()
    {
        GMSheet.SetActive(false);
        yield return new WaitForSeconds(1f);
        isSheetActive = false;
    }
}
