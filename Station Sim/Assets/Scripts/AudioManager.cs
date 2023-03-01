using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
            return;
        s.Source.Play();
    }
}
