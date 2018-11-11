using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10.0f;

    

    public void Attract(Transform body)
    {
        //normalized direction of the body and the planet
        Vector3 TargetDirection = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        
        //set rotation of the body
        body.rotation = Quaternion.FromToRotation(bodyUp, TargetDirection) * body.rotation;

        //add force towards the cantre of the planet with gravity strength
        body.GetComponent<Rigidbody>().AddForce(TargetDirection * gravity);
    }
}
