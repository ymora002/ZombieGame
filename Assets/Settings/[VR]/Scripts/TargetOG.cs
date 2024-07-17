using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOG : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem _particleSystem;

    private Vector3 _randomRotation;
    private bool _isDisabled;

    private void Awake()
    {
        _randomRotation = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
    }

    // Update is called once per frame
    void Update() => Rotate();

    private void Rotate() => transform.Rotate(_randomRotation);

    private void OnCollisionEnter(Collision other)
    {
        if (!_isDisabled && other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject.gameObject);
            ToggleTarget();
            TargetDestroyEffect();
            Invoke("ToggleTarget", 3f);

        }
    }

    private void ToggleTarget()
    {
        _meshRenderer.enabled = _isDisabled;
        _boxCollider.enabled = _isDisabled;

        _isDisabled = !_isDisabled;
    }

    private void TargetDestroyEffect()
    {
        var random = Random.Range(0.8f, 1.2f);

        _audioSource.pitch = random;
        _audioSource.Play();
    }
}
