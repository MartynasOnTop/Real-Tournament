using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
