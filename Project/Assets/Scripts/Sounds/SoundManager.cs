using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [field: SerializeField] public AudioClip JumpIntoWater { get; private set; }
    [field: SerializeField] public AudioClip Die { get; private set; }
    [field: SerializeField] public AudioClip SellItem { get; private set; }
    [field: SerializeField] public AudioClip DiscardItem { get; private set; }
    [field: SerializeField] public AudioClip EnterShop { get; private set; }
    [SerializeField] private AudioSource randomAudioSource;
    [SerializeField] private List<AudioClip> collectSounds;
    [SerializeField] private AudioSource laserAudioSource;

    [SerializeField] private AudioSource stoneBreakingAudioSource;
    [SerializeField] private List<AudioClip> stoneBreakingClips;
    [SerializeField] private AudioClip stoneDestroySound;


    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        randomAudioSource.PlayOneShot(clip);
    }

    public void PlayLaser()
    {
        if (!laserAudioSource.isPlaying)
            laserAudioSource.Play();
    }

    public void StopLaser()
    {
        if (laserAudioSource.isPlaying)
            laserAudioSource.Stop();
    }

    public void PlayStoneDestroyedSound()
    {
        stoneBreakingAudioSource.PlayOneShot(stoneDestroySound);
    }
    
    public void PlayRandomSoundOfType(SoundType type, bool playWhenAudiosSourceIsPlaying = true)
    {
        List<AudioClip> list = new();
        AudioSource audioSource = null;

        switch (type)
        {
            case SoundType.destroyingBlock:
                list = stoneBreakingClips;
                audioSource = stoneBreakingAudioSource;
                break;
            case SoundType.collectSounds:
                list = collectSounds;
                audioSource = randomAudioSource;
                break;
        }


        if (!playWhenAudiosSourceIsPlaying)
        {
            if (audioSource.isPlaying)
                return;
        }

        audioSource.PlayOneShot(list[Random.Range(0, list.Count)]);
    }
}

public enum SoundType
{
    destroyingBlock,
    collectSounds
}