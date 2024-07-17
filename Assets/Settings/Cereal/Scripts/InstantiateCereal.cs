using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCereal : MonoBehaviour
{
    public GameObject cereal;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 15 == 0 && count < 64)
        {
            Instantiate(cereal, transform.position, transform.rotation, transform.parent);
            count++;
        }
    }
}
