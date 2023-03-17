using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
[System.Serializable]
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;
    public  AudioSource _source;
    public static AudioManager instance;
    public AudioMixer mixer;

    public float masterVolume;
    public float soundEffectVolume;
    public float backgroundVolume;
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
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnValidate()
    {
        /*
             public AudioClip[] sounds_clip;

         foreach (AudioClip clip in sounds_clip)
        {
            var s = new Sound();
            s.clip = clip;
            s.name = clip.name;
            sounds.Add(s);
        }
         */
        foreach (Sound s in sounds)
        {
            if (s.clip == null) continue;
            s.name = s.clip.name;
        }
        
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }

    public void Play(string name)
    {
        setMixerValues();
        Sound s= sounds.Find(sounds1 => sounds1.name.Equals(name));
        Debug.Log(s.name);
      
        float dw;
        mixer.GetFloat("MasterVolume", out dw);
        Debug.Log(dw);
        Debug.Log(Mathf.Log10(dw)*20);

        _source.volume = dw;
        Debug.Log(dw);
        if (s == null) return;
        Debug.Log("play sound "+ name);
        _source.clip = s.clip;
        _source.Play();
    }

    public void setMixerValues()
    {
        mixer.SetFloat("MasterVolume", masterVolume);
        mixer.SetFloat("effectVolume", soundEffectVolume);
        mixer.SetFloat("backgroundVolume", backgroundVolume);

    }

    public void PlayRandom()
    {
        setMixerValues();

        Sound s=    sounds[Random.Range(0, sounds.Count - 1)];

        if (s == null) return;
        
        _source.clip = s.clip;
       _source.Play();
    }
}
