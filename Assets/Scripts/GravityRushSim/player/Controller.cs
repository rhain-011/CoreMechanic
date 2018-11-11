using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject playerObject;
    public RaycastHit hit;

    private ZeroG zeroGravity;
    private playerNormalMovement playerController;
    private Rigidbody myRB;
    private AudioSource[] zeroGAudio;
    private Vector3 velocityState = Vector3.zero;
    private Vector3 angularVelocityState = Vector3.zero;
    private Camera camera;

    private bool zeroGEnabled = false;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        zeroGravity = playerObject.GetComponent<ZeroG>();
        playerController = playerObject.GetComponent<playerNormalMovement>();
        myRB = playerObject.GetComponent<Rigidbody>();
        zeroGAudio = playerObject.GetComponents<AudioSource>();
        camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        if(playerController.reached == true)
        {
            StartCoroutine(FadeOut(3, 0.2f));
            camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 60, 0.1f);
        }

        //goto target location
        if(Input.GetButtonDown("Fire1") && zeroGEnabled)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Physics.Raycast(ray, out hit);
            Debug.DrawRay(hit.point, hit.normal, Color.cyan, 5.0f);
            DisableZeroG();
            playerController.reached = false;
            zeroGAudio[3].Play();
            zeroGAudio[3].volume = 1.0f;
            StartCoroutine(playerController.JumpToWall(hit.point, hit.normal));

        }
		
        //enable zero gravity
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(zeroGEnabled == false)
            {
                enableZeroG();
                enableZeroGAudio();

            }
            else
            {
                DisableZeroG();
            }
        }

	}

    private void enableZeroG()
    {
        zeroGEnabled = true;
        playerController.enabled = false;
        //Destroy(myRB);
        //playerObject.AddComponent<Rigidbody>();
        velocityState = myRB.velocity;
        angularVelocityState = myRB.angularVelocity;
        myRB.velocity = Vector3.zero;
        myRB.angularVelocity = Vector3.zero;
        zeroGravity.enabled = true;

    }

    private void enableZeroGAudio()
    {
        zeroGAudio[0].Play();
        zeroGAudio[0].volume = 8.0f;
        zeroGAudio[1].PlayDelayed(.2f);
        zeroGAudio[1].volume = 1.0f;
    }

    private void DisableZeroG()
    {
        DisableZeroGAudio();
        zeroGEnabled = false;
        zeroGravity.enabled = false;
        //Destroy(myRB);
        //playerObject.AddComponent<Rigidbody>();
        playerController.enabled = true;
        myRB.velocity = velocityState;
        myRB.angularVelocity = angularVelocityState;
    }

    private void DisableZeroGAudio()
    {
        if(zeroGAudio[0].isPlaying)
            StartCoroutine(FadeOut(0, 0.1f));

        StartCoroutine(FadeOut(1, 0.1f));
    }

    public IEnumerator FadeOut(int track, float speed)
    {
        float audioVolume = zeroGAudio[track].volume;

        while(zeroGAudio[track].volume >= speed)
        {
            audioVolume -= speed;
            zeroGAudio[track].volume = audioVolume;
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
