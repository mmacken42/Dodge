using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnInput : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            source.Play();
        }
    }
}
