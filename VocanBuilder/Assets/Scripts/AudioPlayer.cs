using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public void PlayTheAudio(AudioSource audio)
    {
        audio.Play();
    }
}
