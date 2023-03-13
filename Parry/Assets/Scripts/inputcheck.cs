
    using UnityEngine;

    public class inputcheck :MonoBehaviour 
    {
        private MainInput input;

        void Awake()
        {
            input = new MainInput();
        }

        private void Update()
        {
            if (input.Character.parry.WasPerformedThisFrame())
            {
               AudioManager.instance.PlayRandom();
            }
        }

        public void playrandomaudio()
        {
            AudioManager.instance.Play(AudioManager.instance.sounds[Random.Range(0, AudioManager.instance.sounds.Length - 1)].name);
        }
        

        private void OnDisable()
        {
        
            input.Disable();
        }
        private void OnEnable()
        {
        
            input.Enable();
        }    
    }