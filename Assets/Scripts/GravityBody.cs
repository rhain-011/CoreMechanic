using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// automatically add rigidbody component to object this script is attached to
[RequireComponent (typeof(Rigidbody))]
public class GravityBody : MonoBehaviour {

    GravityAttractor planet;

    private void Awake()
    {

        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();

        // set unity gravity to false and constraint object rotaion
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        float distanceToPlanet = Vector3.Distance(transform.position, planet.transform.position);
        if (distanceToPlanet < 100)
        {
            planet.Attract(transform);
        }

        // todo Debug.Log(distanceToPlanet);

    }
}
