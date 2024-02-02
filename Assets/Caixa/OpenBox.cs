using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    public GameObject dobra1;
    public GameObject dobra2;

    public float speed = 10f;
    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z_angles_dobra1 = dobra1.transform.localRotation.eulerAngles.z;
        if (z_angles_dobra1 < 135) 
            dobra1.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        float z_angles_dobra2 = dobra2.transform.localRotation.eulerAngles.z;
        if (z_angles_dobra2 < 135) 
            dobra2.transform.Rotate(0, 0, (rotationSpeed * Time.deltaTime));
    }
}
