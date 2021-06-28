using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dove : MonoBehaviour
{
    public GameObject[] doves = new GameObject[3];
    public SpriteRenderer[] doveSprites = new SpriteRenderer[3];
    public int length;

    public SpriteChanger script;
    void Start()
    {
        length = doves.Length;
        for (int i = 0; i < length; i++)
        {
            doveSprites[i] = doves[i].GetComponent<SpriteRenderer>();
        }
    }

    public void ButtonNextCaller()
    {
        script.ButtonNext(doveSprites, length);
        
    }

    public void ButtonPrevoiusCaller()
    {
        script.ButtonPrevious(doveSprites, length);
    }
}
