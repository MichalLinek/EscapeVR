using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    public AudioClip GameMusic;
    private AudioSource audioSource;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = GameMusic;
        audioSource.Play();
    }
}
