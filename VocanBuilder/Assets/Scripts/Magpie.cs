using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magpie : MonoBehaviour
{
    

    public GameObject[] magpies = new GameObject[3];
    public SpriteRenderer[] magpieSprites = new SpriteRenderer[3];
    public int length;

    public SpriteChanger script;

    void Start()
    {
        length = magpies.Length;
        for (int i=0;i<length;i++)
        {
            magpieSprites[i] = magpies[i].GetComponent<SpriteRenderer>();
        }
    }

    public void ButtonNextCaller()
    {
        script.ButtonNext(magpieSprites , length);
    }

    public void ButtonPrevoiusCaller()
    {
        script.ButtonPrevious(magpieSprites, length);
    }

}
