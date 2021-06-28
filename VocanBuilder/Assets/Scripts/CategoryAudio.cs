using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryAudio : MonoBehaviour
{
    public GameObject[] audioObjects = new GameObject[10];
    public AudioPlayer script;
    public void FetchAudio(string name)
    {
        for (int i = 0;i<10;i++)
        {
            AudioSource audio = audioObjects[i].GetComponent<AudioSource>();
            if (audio.clip.name == name) script.PlayTheAudio(audio);
            
        }
    }
}
