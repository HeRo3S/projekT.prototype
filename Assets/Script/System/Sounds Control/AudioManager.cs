using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private Sound[] sounds;
    public Sound[] weaponSounds;
    public Sound[] sceneSounds;
    public AudioMixerGroup audioMixer;
    private void MergeSoundsArray()
    {
        sounds = weaponSounds.Concat(sceneSounds).ToArray();
    }
    private void LoadAudioSourceIntoGameobject()
    {
        //Created AudioSource for each Sound object
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = audioMixer;
        }

    }
    private void Awake()
    {
        //Singleton
        DontDestroyOnLoad(this);
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        InstanceManager.Instance.audioManager = this;
        MergeSoundsArray();
        LoadAudioSourceIntoGameobject();
    }

    private void Start()
    {
        //Play main theme
        Play("maintheme");
        //Play ambient sound
        Play("ambient_cicadas");
        
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }
    public void LoopAudioInUpdateFunction(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying) return;
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

}
