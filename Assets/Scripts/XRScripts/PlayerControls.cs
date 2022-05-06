using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using System.Linq;

public class PlayerControls : MonoBehaviour
{
    public GameObject playerSheet;

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



    //Inventory
    public InventoryObject inventory;
    //public GameObject inventoryUI;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNodeL, devices);
        InputDevices.GetDevicesAtXRNode(xrNodeR, devices);
        device = devices.FirstOrDefault();
    }
    private void Awake()
    {
        
    }

    void Start()
    {
        //These will hopefully be filled with prefabs soon
        playerSheet = GameObject.FindGameObjectWithTag("PlayerSheet");
        //inventoryUI = GameObject.FindGameObjectWithTag("Inventory");

        inventory = ScriptableObject.CreateInstance<InventoryObject>();

        state = PlayerState.InRoom;
        Debug.Log(state.ToString());
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
        if(playerSheet == null)
        {
            playerSheet = Instantiate(Resources.Load("ClassInfoCanvas")) as GameObject;
            playerSheet.transform.SetParent(this.transform.GetChild(0));
            yield return new WaitForSeconds(1f);
            playerSheet.transform.SetParent(this.transform.GetChild(0).transform.GetChild(2));
            playerSheet.transform.localPosition = new Vector3(0f, .4f, 0.2f);
            playerSheet.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
            playerSheet.transform.localScale = new Vector3(.0025f, .0025f, 1f);
        }
        else if(playerSheet != null)
        {
            playerSheet.SetActive(true);
        }
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



    //Handles collisions for adding items to player inventory
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            var item = other.gameObject.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
        }
        
    }
}
