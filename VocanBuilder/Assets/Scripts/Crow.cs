using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public GameObject[] crows = new GameObject[3];
    public SpriteRenderer[] crowSprites = new SpriteRenderer[3];
    public int length;

    public SpriteChanger script;

    void Start()
    {
        length = crows.Length;
        for (int i = 0; i < length; i++)
        {
            crowSprites[i] = crows[i].GetComponent<SpriteRenderer>();
        }
    }

    public void ButtonNextCaller()
    {
        script.ButtonNext(crowSprites, length);
    }

    public void ButtonPrevoiusCaller()
    {
        script.ButtonPrevious(crowSprites, length);
    }
}
