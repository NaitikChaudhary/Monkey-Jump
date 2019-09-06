using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFx;

    [SerializeField]
    private AudioClip jumpClip, gameOverClip;

    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    public void JumpSoundFx() {
        soundFx.clip = jumpClip;
        soundFx.Play();
    }

    public void GameOverSoundFx() {
        soundFx.clip = gameOverClip;
        soundFx.Play();
    }
}
