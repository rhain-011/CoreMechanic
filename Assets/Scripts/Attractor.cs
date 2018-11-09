using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// brakeys implementation
/// </summary>


public class Attractor : MonoBehaviour {

    //gravitational constant
    const float G = 667.4f;

    public static List<Attractor> Attractors;

    // make sure every attractor has a rigidbody component
    public Rigidbody rb;

    void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Attractor>();
        }
        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void FixedUpdate()
    {

        //loop through the list of attractor in the array attractors
        foreach (Attractor attractor in Attractors)
        {
            // prevent from looping itself
            if (attractor != this)
            {
                Attract(attractor);
            }
           
        }
    }

    // argument takes an attractor class obj the you want to attract
    void Attract(Attractor objToAttract)
    {

        // access for rigidbody to attract
        Rigidbody rbToAttract = objToAttract.rb;

        // direction of objet to attract
        // current position - other obj position
        Vector3 direction = rb.position - rbToAttract.position;

        // distance between the objects
        // .magnitude returns length of direction vector
        float distance = direction.magnitude;

        // prevent intantiating from to the same position when duplicating
        if (distance == 0.0f)
        {
            return;
        }

        // calculate magnitude of force
        // use Force = Gravitational constant x ((mass1 x mass2/distance^2)*gravitational constant)
        float forceMagnitude = G* (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);

        // force vector
        // apply force in the direction of object with a magnitude/strength of forceMagnitude
        Vector3 force = direction.normalized * forceMagnitude;

        // apply force to rigidbody
        rbToAttract.AddForce(force);

    }

}
