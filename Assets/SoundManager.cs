using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] Sounds;

    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        foreach (var s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
       var s = Array.Find(Sounds, sound =>  sound.name == name);
        s.source.Play();
    }

    public AudioClip GetClip(string name)
    {
        var s = Array.Find(Sounds, sound =>  sound.name == name);
        return s.clip;
    }
}
