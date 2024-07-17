using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritTransform : MonoBehaviour
{
    [SerializeField] private bool isPositionInherited;
    [SerializeField] private bool isRotationInheritedX;
    [SerializeField] private bool isRotationInheritedY;

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = isPositionInherited ? target.transform.localPosition : transform.localPosition;

        transform.localPosition = new Vector3(isPositionInherited ? target.transform.localPosition.x : transform.localPosition.x,
                                            transform.localPosition.y,
                                            isPositionInherited ? target.transform.localPosition.z : transform.localPosition.z);

        //transform.localRotation = isRotationInherited ? target.transform.localRotation : transform.localRotation;

        /*
        transform.localRotation = Quaternion.Euler(isRotationInheritedX ? target.transform.localRotation.x : transform.localRotation.x,
                                                   isRotationInheritedY ? target.transform.localRotation.y : transform.localRotation.y,
                                                   0);
        */

        transform.eulerAngles = new Vector3(isRotationInheritedX ? target.transform.eulerAngles.x : transform.eulerAngles.x,
                                            isRotationInheritedY ? target.transform.eulerAngles.y : transform.eulerAngles.y,
                                            0);
    }
}
