using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound  
{
    public AudioClip clip;
    public string name;

    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
    public float roll;
    [Range(0f,4f)]
    public float speed;
    public float pitchSpeed;
    public float rollSpeed;
    public float speedSpeed;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
