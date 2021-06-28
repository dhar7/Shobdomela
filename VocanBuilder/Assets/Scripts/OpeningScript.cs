using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour
{
    public void Test()
    {
        SceneManager.LoadScene("GameModes");
    }

    public void Practice()
    {
        SceneManager.LoadScene("CategoryUI");
    }
}
