using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;

    public static SoundManager instance;

    public enum SoundType
    {
        Attack,
        Damage,
        Death,
    }

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Sound(SoundType type)
    {
        audioSource.PlayOneShot(audioClip[(int)type]);
    }
}
