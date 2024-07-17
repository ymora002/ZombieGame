using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorgiSenses : MonoBehaviour
{
    public CorgiAI Corgi;

    public string Tag = "Player";

    bool isTriggered;

    Collider other;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            this.other = other;
            Corgi.isPlayerVisible = true;
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            isTriggered = false;
            this.other = null;
            Corgi.isPlayerVisible = false;
            Corgi.isPlayerNearby = false;
        }
    }

    void Update()
    {
        if (isTriggered && (!other || !other.gameObject.activeSelf))
        {
            Corgi.isPlayerVisible = false;
            Corgi.isPlayerNearby = false;

        }
    }
}
