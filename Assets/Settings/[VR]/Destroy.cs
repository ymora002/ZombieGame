using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public string KeyTag;
    public AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == KeyTag)
        {
            Destroy(other.gameObject);
        }

        _audioSource.Play();
    }

}
