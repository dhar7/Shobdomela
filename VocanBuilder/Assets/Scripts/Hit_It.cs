using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hit_It : MonoBehaviour
{
    Vector3 ray;
    RaycastHit2D hit;
    Vector2 ray2d;
    public GameObject[] targetsArray;
    InstantiateMovableObjects script;
    float time = 0f;

    void Start()
    {
         script = GetComponent<InstantiateMovableObjects>(); 
    }
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0))
        {
             ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             ray2d = new Vector2(ray.x,ray.y);
             hit = Physics2D.Raycast(ray2d,Vector2.zero);
             if(hit.collider.gameObject.tag == "Target")
             {
                 //Debug.Log(hit.collider.gameObject.tag);
                 Destroy(hit.collider.gameObject);
             }
             
        } 

        targetsArray = GameObject.FindGameObjectsWithTag("Target");   
        if(targetsArray.Length == 0) 
        {
            script.enabled = false ; 
            GameObject [] distractors = GameObject.FindGameObjectsWithTag("Distractor");
            foreach(GameObject distractor in distractors)
            {
                GameObject.Destroy(distractor);
            }
            GameObject.Find("GameOver").GetComponent<Image>().enabled = true;
            time += Time.deltaTime;
            if(time>=1f)
            {
                GameModes.target_and_distractor_identity.Clear();
                SceneManager.LoadScene("GameModes");
            }
        }
    }

    
}
