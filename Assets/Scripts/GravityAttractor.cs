using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour {
    
    public float gravity = -10.0f;

    public void Attract(Transform body)
    {
        Vector3 TargetDirection = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.rotation = Quaternion.FromToRotation(bodyUp, TargetDirection) * body.rotation;
        body.GetComponent<Rigidbody>().AddForce(TargetDirection * gravity);
    }
}
