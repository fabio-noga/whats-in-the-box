using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goUpCamp : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        var pos = transform.position;

        if (pos.y<-2)
        { 
                pos.y += 0.03f;
                transform.position = pos;
        }

    }
}
