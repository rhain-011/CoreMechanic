using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    
    public GameObject FppCamera; // 0
    public GameObject TppCamera; // 1
    public GameObject Crossair;
    
    public int CamMode;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("SwitchCam"))
        {
            if (CamMode == 0)
            {
                CamMode = 1;
            }
            else
            {
                CamMode = 0;
            }
            StartCoroutine(CamSwitch());
        }
	}

    IEnumerator CamSwitch()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            Crossair.SetActive(true);
            TppCamera.SetActive(false);
            FppCamera.SetActive(true);
        }
        if (CamMode == 1)
        {
            Crossair.SetActive(false);
            FppCamera.SetActive(false);
            TppCamera.SetActive(true);
        }
    }
}
