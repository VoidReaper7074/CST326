using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    // Start is 9called before the first frame update
    public static SoundManger Instance = null;

    public AudioClip alienBuzz1;
    public AudioClip alienBuzz2;
    public AudioClip alienDies;
    public AudioClip bulletFire;
    public AudioClip shipExplosion;

    private AudioSource soundEffectAudio;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if( Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
        
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
