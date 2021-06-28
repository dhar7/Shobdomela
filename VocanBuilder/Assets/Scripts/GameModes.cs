using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 


public class GameModes : MonoBehaviour
{
    public static int target=1;
    public static int distractor=1;
    public static int minute = 0;
    public static int seconds = 15;
    public List<string> targetList = new List<string>();
    public List<string> distractortList = new List<string>();
    public static Dictionary<string, int> target_and_distractor_identity = new Dictionary<string, int>();
    public static bool [] targetsChecked = new bool[10] { false,false,false,false,false,false,false,false,false,false};
    public static bool [] distractorsChecked = new bool[10] { false,false,false,false,false,false,false,false,false,false};

    bool atleastOneTargetChecked = false ;
    bool atleastOneDistractorChecked = false ;
    GameObject nextButton ;

    public void Start()
    {
        //get button "Next" and set false initially
        nextButton = GameObject.Find("Next");
        nextButton.SetActive(false);
        //assign index values to all categories , this facilates short lines of coding as it avods using if,else-if block
        target_and_distractor_identity.Add( "Birds" , 0);
        target_and_distractor_identity.Add( "Animals" , 1);
        target_and_distractor_identity.Add( "Fruits" , 2);
        target_and_distractor_identity.Add( "Flowers" , 3);
        target_and_distractor_identity.Add( "Vegetables" , 4);
        target_and_distractor_identity.Add( "Shapes" , 5);
        target_and_distractor_identity.Add( "Colors" , 6);
        target_and_distractor_identity.Add( "People" , 7);
        target_and_distractor_identity.Add( "Vehicles" , 8);
        target_and_distractor_identity.Add( "Flags" , 9);

    } void Update()
    {
        //Checking if a user is allowed to go next scene
        //Conditions for going next scene:
        //1.At least 1 target clicked
        //2.At least 1 distractor clicked
        for (int i=0; i<10 ;i++)
        { 
            if (targetsChecked[i]==true) { atleastOneTargetChecked = true ; break ;} 
            else atleastOneTargetChecked = false;
        }
        for (int i=0; i<10 ;i++)
        { 
            if (distractorsChecked[i]==true) { atleastOneDistractorChecked = true ; break ;}
            else atleastOneDistractorChecked = false ; 
        }

        if( atleastOneTargetChecked && atleastOneDistractorChecked) nextButton.SetActive(true);
        else nextButton.SetActive(false);
    }
    public void HandleInputData(int val)
    {
        if(val == 0) target = 1;
        else if(val == 1) target = 2;
        else if(val == 2) target = 3;
        Debug.Log(target);
    }
    public void HandleInputData2(int val)
    {
        if(val == 0) distractor = 1;
        else if(val == 1) distractor = 2;
        else if(val == 2) distractor = 3;
        Debug.Log(distractor);
    }
    public void HandleInputData3(int val)
    {
        if(val == 0) minute = 0;
        else if(val == 1) minute = 1;
        else if(val == 2) minute = 2;
        else if(val == 2) minute = 3;
        Debug.Log(minute);
    }
    public void HandleInputData4(int val)
    {
        if(val == 0) seconds = 15;
        else if(val == 1) seconds = 30;
        else if(val == 2) seconds = 45;
        Debug.Log(seconds);
    }
    public void TargetAdded()
    {
        string targetName = EventSystem.current.currentSelectedGameObject.name;
        targetsChecked[ target_and_distractor_identity[targetName] ] = !(targetsChecked[ target_and_distractor_identity[targetName] ]);
        if (targetsChecked [ target_and_distractor_identity [targetName]] == true) EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.red;
        else EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color32(212,199,47,255);
        GameObject [] arrayOfDistractorObjects = GameObject.FindGameObjectsWithTag("Distractor");
        for(int i=0;i<arrayOfDistractorObjects.Length;i++)
        {
            if(arrayOfDistractorObjects[i].name == targetName) arrayOfDistractorObjects[i].GetComponent<Button>().interactable = false;
            
        }
        
    }
    public void DistractorAdded()
    {
        string distractorName = EventSystem.current.currentSelectedGameObject.name;
        distractorsChecked[ target_and_distractor_identity[distractorName] ] = !(distractorsChecked[ target_and_distractor_identity[distractorName] ]);
        if ( distractorsChecked[ target_and_distractor_identity[distractorName] ] == true ) EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.red;
        else EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color  = new Color32(92,214,134,255);
        GameObject [] arrayOfTargetObjects = GameObject.FindGameObjectsWithTag("Target");
        for(int i=0;i<arrayOfTargetObjects.Length;i++)
        {
            if(arrayOfTargetObjects[i].name == distractorName) arrayOfTargetObjects[i].GetComponent<Button>().interactable = false;
            
        }
    }

    public void GoTONextScene()
    {
        SceneManager.LoadScene("MovingScene");
    }
    public void MainScene()
    {
        target_and_distractor_identity.Clear();
        SceneManager.LoadScene("OpeningScene");
    }

}
