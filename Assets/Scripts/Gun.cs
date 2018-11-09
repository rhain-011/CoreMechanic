using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10.0f;
    public float range = 100.0f;
    public float fireRate = 15.0f;
    public float impactForce = 60.0f;

    //public GameObject impactEffect; reference to impact paricle effect
    public Camera fpsCam;
    public ParticleSystem muzzleFlash; // muzzle flash reference                                      

    private float nextTimeToFire = 0.0f;

	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1.0f / fireRate;
            Shoot();
        }
	}

    void Shoot()
    {
        //play muzzle flash every Shoot() call
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //check if transform has a Target component
            Target target = hit.transform.GetComponent<Target>();

            //if true target takes damage
            if (target != null)
            {
                target.takeDamage(damage);
            }

            // add force to a rigidbody that is hit
            // knock back effect
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //add impact particle effect
            /*
            GameObject impactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObj, 2.0f);
            */

        }
    }

}
