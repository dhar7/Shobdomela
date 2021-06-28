using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class categoryScript : MonoBehaviour
{
    
    
    static public string sceneName;
    public Button prevButton = null;
    public CategoryAudio audioScript;
    public GameObject[] gameObjects ;



    public void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void Rescaler(Button button) // to rescale images and play audio
    {
        if(button != prevButton) 
        {
            prevButton.transform.localScale = new Vector2(.5f, 2.0f);
            button.transform.localScale = new Vector2(.8f, 2.5f);
            prevButton = button;
            audioScript.FetchAudio(button.name);
        }
        
    }

    public void ChangeScene(Button button) // to change scene
    {
        string name = button.name;
        string newName = null;
        for(int i=0; i< name.Length; i++)
        {
            if (i != 0 && name[i] == 'B') break;
            else newName += name[i].ToString();
            
        }
        SceneManager.LoadScene(newName);
       
    }

    public void BackToCategory()
    {
        SceneManager.LoadScene("CategoryUI");
    }

    public void ViewRecords()
    {
         GameObject[] objects = GameObject.FindGameObjectsWithTag("Objects");
         Button[] buttons = new Button[10]; 
         for (int i=0;i<10;i++) buttons[i] = objects[i].GetComponent<Button>();
         for (int i=0;i<10;i++) DynamicTable.objectsHolder[i] = buttons[i].GetComponentInChildren<Text>().text;
         DynamicTable.sceneName = MainSceneObjectsBanglaName.nameInBangla;
         SceneManager.LoadScene("Data");
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("OpeningScene");
    }

}
