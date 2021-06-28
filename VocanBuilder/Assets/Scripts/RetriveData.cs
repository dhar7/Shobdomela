using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetriveData : MonoBehaviour
{
    StreamReader reader ;
    GameObject textField;
    void Start()
    {
        textField = GameObject.Find("Text");
        reader = new StreamReader(PracticeScript.filePath);
        string line;
        while ((line = reader.ReadLine()) != null )
        {
            textField.GetComponent<Text>().text += line;
            textField.GetComponent<Text>().text += '\n' ;
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene("AnimalsPractice");
    }
}
