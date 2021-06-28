using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButtonCommunication : MonoBehaviour
{

    public GameObject[] objects = new GameObject[3];
    public SpriteRenderer[] objectsSprites = new SpriteRenderer[3];
    public int length;

    public SpriteChanger script;

    void Start()
    {
        length = objects.Length;
        for (int i = 0; i < length; i++)
        {
            objectsSprites[i] = objects[i].GetComponent<SpriteRenderer>();
        }
    }

    public void ButtonNextCaller()
    {
        script.ButtonNext(objectsSprites, length);
    }

    public void ButtonPrevoiusCaller()
    {
        script.ButtonPrevious(objectsSprites, length);
    }
}
