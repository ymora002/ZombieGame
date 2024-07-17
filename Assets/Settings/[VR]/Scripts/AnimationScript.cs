using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]


public class AnimationScript : MonoBehaviour
{
    public AudioSource audioSource;   
    public enum type {ROTATE, MOVE, PLACE, APPEAR};

    public new type animation = type.ROTATE;

    public bool isTriggered = true;
    public bool isMoving = false;
    public bool isRotating = false;

    bool isReverse;
    Vector3 startPosition;
    Vector3 endPosition;
    Quaternion startRotation;
    Quaternion endRotation;

    GameObject placedObject;

    public string TargetTag = "";
    public Vector3 TargetValue = Vector3.zero;
    public float speed = 16f;

    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startRotation = transform.localRotation;
        startPosition = transform.position;
        endPosition = startPosition + TargetValue;
        endRotation = Quaternion.Euler(startRotation.x + TargetValue.x, startRotation.y + TargetValue.y, startRotation.z + TargetValue.z);


    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = endRotation;
        Vector3 targetPosition = endPosition;

        if (isReverse)
        {
            targetPosition = startPosition - TargetValue;
            targetRotation = Quaternion.Euler(startRotation.x - TargetValue.x, startRotation.y - TargetValue.y, startRotation.z - TargetValue.z);
        }

        if (isRotating)
        {
            //transform.rotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(TargetValue.x, TargetValue.y, TargetValue.z), speed * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(TargetValue.x, TargetValue.y, TargetValue.z), speed * Time.deltaTime);

            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
        }
        else if (isMoving)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }

    public void Reset()
    {
        isRotating = false;
        isMoving = false;

        if (animation == type.MOVE)
        {
            transform.localPosition = startPosition;
            transform.localRotation = startRotation;
        }
        else if (animation == type.ROTATE)
        {
            transform.localRotation = startRotation;
        }


        if (placedObject != null)
        {
            Destroy(placedObject);
        }
    }

    public void Animate(bool inputReverse)
    {
        isReverse = inputReverse;

        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

        if (animation == type.MOVE)
        {
            isMoving = true;
            isRotating = false;
        }
        else if (animation == type.ROTATE)
        {
            isRotating = true;
            isMoving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered && (TargetTag == "" || other.gameObject.tag == TargetTag))
        {
            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
            }

            if (animation == type.MOVE)
            {
                isMoving = true;
                isRotating = false;
            }
            else if (animation == type.ROTATE)
            {
                isRotating = true;
                isMoving = false;
            }
            else if (animation == type.PLACE)
            {
                XRGrabInteractable otherInteractable = other.GetComponent<XRGrabInteractable>();
                Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

                if (otherInteractable != null && otherRigidbody != null)
                {
                    isRotating = false;
                    isMoving = false;
                    otherInteractable.enabled = false;
                    otherRigidbody.isKinematic = true;
                    otherRigidbody.useGravity = false;

                    other.gameObject.transform.position = transform.position + TargetValue;
                    other.gameObject.transform.parent = transform;
                    other.gameObject.transform.localScale = Vector3.one;
                    placedObject = other.gameObject;
                }

            }
        }
    }
}
