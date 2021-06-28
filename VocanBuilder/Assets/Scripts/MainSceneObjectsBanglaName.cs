using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneObjectsBanglaName : MonoBehaviour
{
    static public string nameInBangla ;

    public void NameHOlder(Button button)
    {
       nameInBangla = button.GetComponentInChildren<Text>().text;
    }
}
