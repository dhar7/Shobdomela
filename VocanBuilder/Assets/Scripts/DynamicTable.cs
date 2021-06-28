using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicTable : MonoBehaviour
{
    static public string[] objectsHolder = new string[10];
    static public string sceneName;
    
    void Start()
    {
        TableLoader();
    }

    public void TableLoader()
    {
        GameObject.Find("Name").GetComponent<Text>().text = sceneName;
        GameObject prefab = GameObject.Find("Prefab");
        GameObject model ;
        for (int i = 0;i<10;i++)
        {
            model = Instantiate<GameObject>(prefab,transform);
            model.transform.GetChild(0).GetComponent<Button>().GetComponentInChildren<Text>().text  = objectsHolder[i];
        }
    }

    
}
