using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    AudioSource aud;

    [SerializeField]
    AudioClip buttonBeepSFX;

    public AudioClip ButtonBeepSFX
    {
        get
        {
            return buttonBeepSFX;
        }
    }

    public AudioSource Aud
    {
        get
        {
            return aud;
        }
    }

    private void Awake()
    {
        instance = this;
        aud = GetComponent<AudioSource>();
    }
}
