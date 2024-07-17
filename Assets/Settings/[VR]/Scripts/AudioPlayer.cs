using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;





    private void Awake()
    {
        /*
        if (playerInput.actions != InputManager)
        {
            playerInput.actions = InputManager;
   

            Debug.Log("I AM CULPRIT: " + gameObject.name);
            //playerInput.actions = StartupXRCheck.Instance.InputManager;
            //playerInput.enabled = false;
            //playerInput.enabled = true;


        }
        playerInput.enabled = true;
        */
    }

    private void Start()
    {



    }



    public void PlayExhibit()
    {
        if (audioSource.isPlaying == false) { audioSource.Play(); }
    }

    public void StopExhibit()
    {
        audioSource.Stop();
    }


    private void OnTriggerStay(Collider other)
    {
        if (PlayerMovement.Instance.wasInteracting)
        {
            if (audioSource.isPlaying == false) { audioSource.Play(); }   
        }
    }
}