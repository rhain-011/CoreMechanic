using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiralBridge : MonoBehaviour {

    public Transform prefab;
    private float newAngle = 0f;
    public float newPosition = 79.0f;
    public float numberToInstantiate = 100.0f;

    

	// Use this for initialization
	void Start () {
        //generateSpiralBridge();
        generateCircle(0 ,-62.1f, 10 );
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void generateCircle(float originX, float originY, int numberOfObjectPerQuarter)
    {
        float degreeToAdd = (float)90.0 / numberOfObjectPerQuarter;
        float radius = 4.0f;

        for(float i = 0; i <= 360; i += degreeToAdd)
        {
            float x = originX + (Mathf.Cos(i) * radius);
            float y = originY + (Mathf.Sin(i) * radius);

            Instantiate(prefab, new Vector3(x, 4, y), Quaternion.LookRotation(new Vector3(originX, originY)));
        }
    }
    void generateSpiralBridge()
    {
        for (int i = 0; i < numberToInstantiate; i++)
        {
            newAngle += 3.0f;
            newPosition += 0.5f;
            Instantiate(prefab, new Vector3(newPosition, 0, -65.0f), Quaternion.Euler(newAngle, 0, 0));
        }
    }
}
