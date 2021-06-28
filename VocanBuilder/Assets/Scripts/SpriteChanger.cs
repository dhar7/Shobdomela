using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{

    public int index = 0;
    public void ButtonNext(SpriteRenderer[] sprites , int length)
    {
        if (index == (length - 1))
        {
            sprites[index].enabled = false;
            index = 0;
            sprites[index].enabled = true;
        }
        else
        {
            sprites[index].enabled = false;
            index++;
            sprites[index].enabled = true ;
        }
    }

    public void ButtonPrevious(SpriteRenderer[] sprites, int length)
    {
        if (index == 0)
        {
            sprites[index].enabled = false;
            index = length-1;
            sprites[index].enabled = true;
        }
        else
        {
            sprites[index].enabled = false;
            index--;
            sprites[index].enabled = true;
        }
    }
}
