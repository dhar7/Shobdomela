using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstantiateMovableObjects : MonoBehaviour
{
    public List<string> targets = new List<string>();
    public List<string> distractors = new List<string>();
    public int numberOfTargets,numberOfDistractors;
    public int minute,seconds;
    public float remainingSeconds,remainingMins;
    public GameObject targetPrefab;
    public GameObject distractorPrefab;
    public Sprite[] targetSprite;
    public Sprite[] distractorSprite;
    public GameObject minuteText,secondText;

    public bool timer = true;
    public bool gameOver = false;
    public void Start()
    {
        FetchInformation();
        TargetLoader();
        DistractorLoader();
    }
    void DistractorLoader()
    {
         for(int i=0 ; i < distractors.Count ; i++)
        {
            distractors[i] += "/all";
            distractorSprite = Resources.LoadAll<Sprite>(distractors[i]);
            for (int j=0 ; j<numberOfDistractors ; j++)
            {
                int index = Random.Range(0,30);
                GameObject gameObjectInitiated = Instantiate(distractorPrefab,transform.position,transform.rotation) as GameObject;
                gameObjectInitiated.GetComponent<SpriteRenderer>().sprite = distractorSprite[index];
            }
        }
    }
    void TargetLoader()
    {
         for(int i=0 ; i < targets.Count ; i++)
        {
            targets[i] += "/all";
            targetSprite = Resources.LoadAll<Sprite>(targets[i]);
            for (int j=0 ; j<numberOfTargets ; j++)
            {
                int index = Random.Range(0,30);
                GameObject gameObjectInitiated = Instantiate(targetPrefab,transform.position,transform.rotation) as GameObject;
                gameObjectInitiated.GetComponent<SpriteRenderer>().sprite = targetSprite[index];
            }
        }
    }
    void FetchInformation()
    {
        for (int i=0 ; i< 10 ; i++)
        {
            if (GameModes.targetsChecked[i] == true)
            {
                 foreach( KeyValuePair<string , int> entry in GameModes.target_and_distractor_identity)
                 {
                      if(entry.Value == i) {Debug.Log(entry.Key);targets.Add(entry.Key);} 
                 }
            }
        }

        for (int i=0 ; i< 10 ; i++)
        {
            if (GameModes.distractorsChecked[i] == true)
            {
                 foreach( KeyValuePair<string , int> entry in GameModes.target_and_distractor_identity)
                 {
                      if(entry.Value == i) {Debug.Log(entry.Key);distractors.Add(entry.Key);} 
                 }
            }
        }
        numberOfTargets = GameModes.target;  numberOfDistractors = GameModes.distractor;   
        minute = GameModes.minute; remainingMins = (float)minute ;
        seconds = GameModes.seconds; remainingSeconds = (float)seconds;
        minuteText = GameObject.Find("Min");
        secondText = GameObject.Find("Sec");
        

    }

    public void Update()
    {
        minuteText.GetComponent<Text>().text = ((int)remainingMins).ToString();
        secondText.GetComponent<Text>().text = ((int)remainingSeconds).ToString();
        if(timer)
        {
            remainingSeconds -= Time.deltaTime;
            if (remainingSeconds <= 0f )
            {
                remainingSeconds = 59f;
                if (remainingMins == 0f) 
                {
                    remainingSeconds = 0f;
                    timer = false;
                    gameOver = true;
                    GameObject [] distractors = GameObject.FindGameObjectsWithTag("Distractor");
                    GameObject [] targets = GameObject.FindGameObjectsWithTag("Target");
                    foreach(GameObject distractor in distractors)
                    {
                         GameObject.Destroy(distractor);
                    }
                    foreach(GameObject target in targets)
                    {
                         GameObject.Destroy(target);
                    }
                    GameObject.Find("GameOver").GetComponent<Image>().enabled = true;
                }
                else remainingMins -= 1f;
            }
        }
        
    }

   
}
