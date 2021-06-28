using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class description : MonoBehaviour
{
    AudioSource audioObject;
    public string audioName ;
    AudioClip clip;

    public void Start()
    {
        audioName = ImageAudioHolder.sceneName;
        Debug.Log(audioName);
        audioName = "Audio/" + audioName ;
        clip = Resources.Load<AudioClip>(audioName);
        audioObject = GameObject.Find("audio").GetComponent<AudioSource>();
        audioObject.clip = clip;

    }


    public void ListenDescription()
    {
         
         
         audioObject.Play();
    }

    public void GoBack()
    {
        SceneManager.LoadScene(ImageAudioHolder.sceneName);
    }
}
