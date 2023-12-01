using UnityEngine.Audio;
using System;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{

    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pich;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play2("theme");
    }

    public void Play2(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }
}
