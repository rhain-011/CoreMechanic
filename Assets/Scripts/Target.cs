using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50.0f;

    public void takeDamage(float amount)
    {
        health -= amount;

        if (health <= 0.0f)
        {
            destroyObj();
        }

       
    }

    void destroyObj()
    {
        Destroy(gameObject);
    }
}
