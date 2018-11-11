using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thanks a lot to PushyPixels@Youtube

[RequireComponent(typeof(Rigidbody))]
public class ZeroG : MonoBehaviour {

    public float force = 100.0f;
    public float lookForce = .5f;
    public ForceMode forceMode;

    private Rigidbody myRB;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        transform.position += transform.up + new Vector3(0,1,0);
    }

    
    void FixedUpdate () {
        Vector3 forceDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        myRB.AddTorque(transform.up * lookForce * Input.GetAxis("Mouse X"), ForceMode.VelocityChange);
        myRB.AddTorque(-transform.right * lookForce * Input.GetAxis("Mouse Y"), ForceMode.VelocityChange);
        myRB.AddForce(transform.rotation*forceDirection, forceMode);
    }
}
