using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    public static AudioLibrary Instance;

    public AudioClip EatFood;
    public AudioClip Music;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Instance = this;
    }

    void Start()
    {
        audioSource.clip = Music;
    }

}
