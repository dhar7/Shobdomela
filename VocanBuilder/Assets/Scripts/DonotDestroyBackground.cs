using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroyBackground : MonoBehaviour
{
    
    private void Awake()
    {
        GameObject[] backgroundMusics = GameObject.FindGameObjectsWithTag("BackGround");
        if (backgroundMusics.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
