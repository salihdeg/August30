using System;
using UnityEngine;

namespace Managers
{
    [System.Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;

        [Range(0f, 1f)]
        public float Volume = 0.2f;

        [Range(.1f, 3f)]
        public float Pitch = 1f;

        public bool Loop;

        public bool PlayOnAwake;

        [HideInInspector]
        public AudioSource Source;
    }


    public class AudioManager : MonoBehaviour
    {
        public Sound[] Sounds;
        public static AudioManager Instance;
        public bool Muted;

        private AudioSource _emptySource;

        void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            DontDestroyOnLoad(gameObject);

            _emptySource = gameObject.AddComponent<AudioSource>();
            _emptySource.playOnAwake = false;
            _emptySource.loop = false;

            foreach (Sound s in Sounds)
            {
                s.Source = gameObject.AddComponent<AudioSource>();
                s.Source.clip = s.Clip;
                s.Source.volume = s.Volume;
                s.Source.pitch = s.Pitch;
                s.Source.loop = s.Loop;
                s.Source.playOnAwake = s.PlayOnAwake;
            }
        }

        public void Play(AudioClip clip)
        {
            _emptySource.Stop();
            _emptySource.PlayOneShot(clip);
        }

        public void Play(string name)
        {
            //_emptySource.Stop();
            Sound s = Array.Find(Sounds, sound => sound.Name == name);
            if (s != null)
                s.Source.Play();
        }

        public float GetClipTime(string name)
        {
            Sound s = Array.Find(Sounds, sound => sound.Name == name);
            if (s != null)
                return s.Source.clip.length;

            return 0f;
        }
        
        public void Stop(string name)
        {
            Sound s = Array.Find(Sounds, sound => sound.Name == name);
            if (s != null)
                s.Source.Stop();
        }

        public bool IsPlaying()
        {
            return _emptySource.isPlaying;
        }

        public void StopEmtySource()
        {
            _emptySource.Stop();
        }

        public void ChangeVolumeStatus()
        {
            if (Muted)
            {
                _emptySource.mute = false;
                foreach (Sound s in Sounds)
                {
                    s.Source.volume = s.Volume;
                }
                Muted = false;
            }
            else
            {
                _emptySource.mute = true;
                foreach (Sound s in Sounds)
                {
                    s.Source.volume = 0;
                }
                Muted = true;
            }
        }
    }
}

