using System;
using UnityEngine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public  AudioSource _source;
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        _source.GetComponent<AudioSource>();
        foreach (Sound s in  sounds)
        {
            
           _source.clip = s.clip;
           _source.volume = s.volume;
           _source.pitch = s.pitch;
           _source.loop = s.loop;
        }
    }
    public void Play(string name)
    {
        Sound s= Array.Find(sounds, sounds1 => sounds1.name == name);
        if (s == null) return;
        _source.clip = s.clip;
        _source.Play();
    } 
    public void PlayRandom()
    {
        Sound s=    sounds[Random.Range(0, sounds.Length - 1)];

        if (s == null) return;
        
        _source.clip = s.clip;
       _source.Play();
    }
}
