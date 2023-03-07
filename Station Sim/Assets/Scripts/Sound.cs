using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    public bool Loop;
    public AudioClip Clip;
    [Range(0f, 1f)]
    public float Volume;

    public bool Destruction;
    public bool Construction;
    public bool BackgroundLayer;

    [HideInInspector]
    public AudioSource Source;

}
