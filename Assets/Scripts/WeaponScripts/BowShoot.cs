using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;


public class BowShoot : MonoBehaviour
{
    static private BowShoot S;
    [Header("Set in Inspector")]                                            // a
    public GameObject arrowPrefab;
    public float velocityMult = 8f;
    
    private LineRenderer line;
    // fields set dynamically
    [Header("Set Dynamically")]                                             // a
    public GameObject launchPoint;
    public Vector3 launchPos;                                   // b
    public GameObject projectile;                                  // b
    public bool aimingMode;                                  // b

    private Vector3 projPos;
    private Vector3 topOfBow;
    private Vector3 bottomOfBow;
    private Rigidbody projectileRigidbody;
    private XRController controller;
    
    static public Vector3 LAUNCH_POS
    {                                        // b
        get
        {
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }
    }
    void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");              // a
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);                                          // b
        launchPos = launchPointTrans.position;
        // Get a reference to the LineRenderer
        line = GameObject.Find("BowNoString").GetComponent<LineRenderer>();
        // Disable the LineRenderer until it's needed
        line.enabled = false;
        topOfBow = GameObject.Find("TopAnchor").transform.position;
        bottomOfBow = GameObject.Find("BottomAnchor").transform.position;
    }
    void OnHandHoverBegin(XRBaseInteractable interactable)
    {
        //aimingMode = true;
        //line.enabled = true;
        //line.SetPosition(0, bottomOfBow);
        //line.SetPosition(1, topOfBow);
        launchPoint.SetActive(true);
    }
    void OnHandHoverEnd(XRBaseInteractable interactable)
    {
        //aimingMode = false;
        //line.enabled = false;
        launchPoint.SetActive(false);
    }
    void OnGrab()
    {
        // The player has pressed the grab button while hovering over the point
        aimingMode = true;
        // Instantiate a Projectile
        projectile = Instantiate(arrowPrefab) as GameObject;
        // Start it at the launchPoint
        projectile.transform.position = launchPos;
        // Set it to isKinematic for now
        projectileRigidbody = projectile.GetComponent<Rigidbody>();                // a
        projectileRigidbody.isKinematic = true;                                    // a
        //line.enabled = true;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        // If not in aimingMode, don't run this code
        if (!aimingMode) return; 

        // get current hand positions
        Vector3 pos = transform.position;
        Vector3 destination = launchPos;
        // Get the direction from the launchPos to the hand
        Vector3 offset = pos - launchPos;
        float maxArc = this.GetComponent<SphereCollider>().radius;
        // If the direction is within the maxArc, set the destination to the hand
        if (offset.magnitude <= maxArc)
        {
            destination = pos;
        }
        // Set the LineRenderer positions
        line.SetPosition(0, bottomOfBow);
        line.SetPosition(1, destination);
        // If the player releases the grab button, launch the arrow
        if (XRInteractionManager.Get().currentInteractionType == XRInteractionType.None)
        {
            aimingMode = false;
            line.enabled = false;
            // Get a reference to the Rigidbody from the instantiated Projectile
            projectileRigidbody.isKinematic = false;                                 // a
            projectileRigidbody.velocity = -transform.forward * velocityMult;
            projectileRigidbody.useGravity = true;
            projectileRigidbody.AddForce(new Vector3(0, -9.81f, 0));
            projectile = null;
        }
        
    }
    */
    void Update()
    {
        // Ifnot in aimingMode, don't run this code
        if (!aimingMode) return;

        // Get the current position of the hand
        Vector3 handPos = controller.transform.position;
        // Get the direction from the launchPos to the hand
        Vector3 offset = handPos - launchPos;
        // If the direction is within the maxArc, set the destination to the hand
        float maxArc = this.GetComponent<SphereCollider>().radius;
        if (offset.magnitude <= maxArc)
        {
            projPos = handPos;
        }
        // move the projectile to the new position
        Vector3 projePos = launchPos + offset;
        projectile.transform.position = projePos;
        Vector3[] points = new Vector3[] {bottomOfBow, topOfBow, projePos};
        DrawBand(points);
        
        
    }
    public void DrawBand(Vector3[] positions)
    {
        line.loop = true;
        line.positionCount = 3;
        line.SetPositions(positions);
        line.enabled = true;
    }
}
