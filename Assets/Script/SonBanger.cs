using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SonBanger : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private float volume;

    [SerializeField] private float pitch;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        volume = 50f;
        pitch = 1f;
        source.clip = sound;
        source.volume = volume;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
}