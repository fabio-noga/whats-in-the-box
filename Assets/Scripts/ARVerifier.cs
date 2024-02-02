using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARVerifier : MonoBehaviour
{
    public GameObject ARObject;

    void Awake()
    {
        if (!GameObject.Find("AR"))
        {
            var AR = Instantiate(ARObject,transform.position,transform.rotation);
            AR.name = "AR";
        }
    }
}
