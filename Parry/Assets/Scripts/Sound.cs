    
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
    public class Sound
    {
        public AudioClip clip;

        public string name;
        [Range(0f, 1f)] public float volume=1;
        [Range(1f, 3f)] public float pitch;

        public bool loop;
        
    }
