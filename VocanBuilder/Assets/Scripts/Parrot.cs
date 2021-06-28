using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour
{
    public GameObject[] parrots = new GameObject[4];
    public SpriteRenderer[] parrotSprites = new SpriteRenderer[4];
    public int length;

    public SpriteChanger script;
    void Start()
    {
        length = parrots.Length;
        for (int i = 0; i < length; i++)
        {
            parrotSprites[i] = parrots[i].GetComponent<SpriteRenderer>();
        }
    }

    public void ButtonNextCaller()
    {
        script.ButtonNext(parrotSprites, length);
    }

    public void ButtonPrevoiusCaller()
    {
        script.ButtonPrevious(parrotSprites, length);
    }
}
