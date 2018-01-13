using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class floatObject : MonoBehaviour {
    public float waterLevel = 0.0f;
    public float floatTheshold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 1.0f;


    float forceFactor;
    Vector3 floatForce;


    // update once per frame
    void FixedUpdate() {
        forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatTheshold);

        if (forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce * GetComponent<Rigidbody>().mass, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);


        }
    }
}
