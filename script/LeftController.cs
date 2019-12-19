using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour
{
    private Quaternion rotate90 = Quaternion.Euler(0, 0, 90);
    private Quaternion currentRotation;
    private Quaternion targetRotation;

    // Update is called once per frame.
    void Update()
    {
        // Using Lerp
        //if (OVRInput.GetUp(OVRInput.Button.Four))
        //{
        //    currentRotation = transform.rotation;
        //    currentRotation = currentRotation * Quaternion.Euler(currentRotation.x, currentRotation.y, 90);   
        //}

        //transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, 0.2f)
        // Using Rotate
        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            transform.Rotate(0, 0, 90);
            //targetRotation = Quaternion.AngleAxis(90, Vector3.forward) * currentRotation;
        }
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
    }
}
