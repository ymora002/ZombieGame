using UnityEngine;

public class EatScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log("Destroy food here.");

            PlayEatSoundEffect();

            CreateFoodCrumbs();
        }
    }

    private void PlayEatSoundEffect()
    {
        float RandomSoundPitchValue = Random.Range(0.8f, 1.2f);

        _audioSource.pitch = RandomSoundPitchValue;
        _audioSource.Play();
    }

    private void CreateFoodCrumbs()
    {
        particleFoodCrumbs.Play();
    }


    #region Setup
    private AudioSource _audioSource;

    public ParticleSystem particleFoodCrumbs;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.clip = AudioLibrary.Instance.EatFood;
    }

    #endregion
}
