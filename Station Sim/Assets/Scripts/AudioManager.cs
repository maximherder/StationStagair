using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    private List<Sound> _constructionSounds = new List<Sound>();
    private List<Sound> _destructionSounds = new List<Sound>();
    private List<Sound> _layerSounds = new List<Sound>();



    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.loop = sound.Loop;
            sound.Source.volume = sound.Volume;

            if (sound.Construction)
                _constructionSounds.Add(sound);
            else if (sound.Destruction)
                _destructionSounds.Add(sound);
            else if (sound.BackgroundLayer)
                _layerSounds.Add(sound);
        }
        Play("Ambience1");
        Play("Ambience2");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
            return;
        s.Source.Play();
    }

    public void PlayConstruction()
    {
        System.Random rand = new System.Random();
        Sound s1 = _constructionSounds[rand.Next(0, _constructionSounds.Count)];
        Sound s2 = _layerSounds[rand.Next(0, _layerSounds.Count)];
        s1.Source.Play();
        s2.Source.Play();
    }

    public void PlayDestruction()
    {
        System.Random rand = new System.Random();
        Sound s1 = _destructionSounds[rand.Next(0, _destructionSounds.Count)];
        Sound s2 = _layerSounds[rand.Next(0, _layerSounds.Count)];
        s1.Source.Play();
        s2.Source.Play();
    }
}
