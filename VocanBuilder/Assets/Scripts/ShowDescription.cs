using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDescription : MonoBehaviour
{
    public string txtContent ;
    TextAsset textAsset;
    public GameObject textField;
    void Start()
    {
        //textField = GameObject.Find("Textbox");
        textAsset = (TextAsset)Resources.Load("Description/Crow");
        txtContent = textAsset.text;
        textField.GetComponent<Text>().text = txtContent;
    }

    
}
