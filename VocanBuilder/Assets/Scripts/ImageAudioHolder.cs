using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ImageAudioHolder : MonoBehaviour
{
    public GameObject[] imageObject = new GameObject[3];
    public GameObject audioObject;
    public GameObject buttonObject;
    public GameObject nameOfObject;
    public int nowShowing = 0;
    public bool[] isCompleted = new bool[3];
    public Button practiceButton;
    static public string sceneName;
    static public string objectName;
    static public string previousSceneName;
    Image image;
    AudioSource audioFile;

    
    

    static public int score;

    
    private void Start()
    {
        GameObject.Find("Points").SetActive(false);
        GameObject.Find("Dollar").SetActive(false);
        //score = int.Parse(GameObject.Find("Points").GetComponent<Text>().text);
        nameOfObject = GameObject.Find("NameOfObject");
        objectName = nameOfObject.GetComponent<Text>().text;
        sceneName = SceneManager.GetActiveScene().name;
        previousSceneName = categoryScript.sceneName;
        buttonObject = GameObject.FindGameObjectWithTag("PracticeButton");
        practiceButton = buttonObject.GetComponent<Button>();
        practiceButton.enabled = false;
        buttonObject.GetComponent<Image>().enabled = false;
        isCompleted[0] = true;
        imageObject = GameObject.FindGameObjectsWithTag("ImageEntity");
        audioObject = GameObject.FindGameObjectWithTag("Audio");
    }

    public void ButtonNext()
    {
        if (nowShowing == 2)
        {
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = false;
            isCompleted[nowShowing] = true;
            nowShowing = 0;
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = true;
            isCompleted[nowShowing] = true;
        }
        else
        {
            // index o disable
            //index o isCompleted 1
            //index 1 enable
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = false;
            isCompleted[nowShowing] = true;
            nowShowing++;
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = true;
            isCompleted[nowShowing] = true;
        }
    }

    public void ButtonPrevious()
    {
        if (nowShowing == 0)
        {
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = false;
            isCompleted[nowShowing] = true;
            nowShowing = 2;
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = true;
            isCompleted[nowShowing] = true;
        }
        else
        {
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = false;
            isCompleted[nowShowing] = true;
            nowShowing--;
            image = imageObject[nowShowing].GetComponent<Image>();
            image.enabled = true;
            isCompleted[nowShowing] = true;
        }
    }

    public void BackToPreviousScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayAudio()
    {
        audioFile = audioObject.GetComponent<AudioSource>();
        audioFile.Play();
    }

    public void GoToPractice(string sceneName)
    {
        SceneManager.LoadScene("AnimalsPractice");
    }

    private void Update()
    {
        if ( (isCompleted[1]==true) && (isCompleted[2] == true) )
        {
            
            practiceButton.enabled = true;
            buttonObject.GetComponent<Image>().enabled = true;
        }
    }

    public void Info()
    {
        string infoSceneName =  sceneName + "_";
        SceneManager.LoadScene(infoSceneName);
    }

}
