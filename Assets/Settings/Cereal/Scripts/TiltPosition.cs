using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltPosition : MonoBehaviour
{
    public Transform tiltTransform;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = tiltTransform.localPosition;
        transform.localRotation = tiltTransform.localRotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
