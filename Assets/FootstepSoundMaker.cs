using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundMaker : MonoBehaviour
{
    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] AudioSource footstepAudioSource;
    private void Awake()
    {
        if(footstepAudioSource == null) footstepAudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }
    public void MakeSound()
    {
        int soundIndex = Random.Range(0, footstepSounds.Length - 1);
        footstepAudioSource.clip = footstepSounds[soundIndex];
        footstepAudioSource.Play();
    }
}
