using System;
using UnityEngine;

public class ExplosionSfMenager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip explosionSfx;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayExplosion()
    {
        audioSource.Play();
    }
}
