using UnityEngine;

public class Target : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Dart"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.up);
            TargetHitEffect();
        }
    }

    private void TargetHitEffect()
    {
        _audioSource.Play();
    }
}
