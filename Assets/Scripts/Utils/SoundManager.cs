using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Terminar esta clase con el video de chadrtronic
    /// </summary>
    public static SoundManager instance { get; private set; }

    private AudioSource[] sources; 
    // 0: music
    // 1: ambient
    // 2: sound effects

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;

        sources = this.GetComponents<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        this.sources[0].PlayOneShot(clip);
    }
    public void PlayAmbient(AudioClip clip)
    {
        this.sources[1].PlayOneShot(clip);
    }
    public void PlayEffect(AudioClip clip)
    {
        this.sources[2].PlayOneShot(clip);
    }
}
