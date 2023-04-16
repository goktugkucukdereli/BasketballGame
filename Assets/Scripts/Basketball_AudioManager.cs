using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball_AudioManager : MonoBehaviour
{
    public static Basketball_AudioManager aManager;
    public AudioClip[] voices;
    public AudioSource[] aSource;

    void Awake()
    {
        if (aManager == null)
        {
            aManager = this;
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 60;
        }
        else if (aManager != null)
            Destroy(gameObject);
    }

    public void ContactVoice()
    {
        aSource[1].PlayOneShot(voices[0]);
    }

    public void ScoreVoice()
    {
        aSource[1].PlayOneShot(voices[1]);
    }

    public void noVoice()
    {
        aSource[1].PlayOneShot(voices[2]);
    }

    public void BasketVoice()
    {
        aSource[1].PlayOneShot(voices[3]);
    }

    public void CrushVoice()
    {
        aSource[1].PlayOneShot(voices[4]);
    }
}
