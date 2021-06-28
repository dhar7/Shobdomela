using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class PracticeScript : MonoBehaviour
{
    public Sprite[] sprite; // hold all 30 sprites of same category for example Animals/People/etc
    public Sprite[] testSprite = new Sprite[3];
    public Sprite[] distractorSprite = new Sprite[2];
    public Sprite finalSprite;
    public string[] sourceSpriteName = new string[3];
    public int[] notSelectingIndex = new int[3];
    static public string sceneName;
    public string sourceSceneName;
    public GameObject[] buttonObject = new GameObject[3] ;
    public int testIndex; // holds index of right answer
    public Button[] button = new Button[3];
    public Image[] imageObject = new Image[3];
    public Button rightButton ; //holds the right button
    public GameObject nameOfObject; //holds the gameobject for which the practice scene appears 
    public GameObject[] optionsObj = new GameObject[3]; //holds all 3 options for practice 
    public GameObject[] helperObject = new GameObject[3]; // hold helper arrow signs
    public string[] distractorObjectName = new string[2]{"",""};
    public GameObject[] timerObject = new GameObject[2];
    float initialSeconds = 0f ;
    float initialMinutes = 0f ;
    public bool appearsEmoji = false;
    public float emojiTimer;
    public bool activateTimer = true; 
    public GameObject pointBox ;
    public GameObject[] practiceBackgroundImageGameObject;
    public GameObject[] pointSprites = new GameObject[12]; 
    public string[] pointSpritesName = new string[12];
    public bool destroyAnimator = false;
    float animatorTime = 0f;
    public int animationIndex = 0;
    public int score;
    public int numberOfAttempts = 1;
    public List<string> distractorsSelected = new List<string>();
    static public string filePath ;
    GameObject seeRecords ; 
    public AudioClip instruction ;

    
    void Start()
    {
        PreLoader();
        SpritenNameMaker();
        TestSpriteSelector();
        AudioInstruction();
        RandomGeneratorDistractor();
        RandomGeneratorFinalSprite();
        ButtonFinder();
        ImageSetter();
    }

    public void PreLoader()
    {
        timerObject = GameObject.FindGameObjectsWithTag("Timer");
        optionsObj = GameObject.FindGameObjectsWithTag("Options");
        nameOfObject = GameObject.Find("NameOfObject");
        practiceBackgroundImageGameObject = GameObject.FindGameObjectsWithTag("PracticeBG");
        practiceBackgroundImageGameObject[Random.Range(0,4)].GetComponent<Image>().enabled = true;
        //pointBox = GameObject.Find("Points");
        //pointBox.GetComponent<Text>().text = ImageAudioHolder.score.ToString();
        nameOfObject.GetComponent<Text>().text = ImageAudioHolder.objectName;
        sourceSceneName = (ImageAudioHolder.sceneName).ToLower();
        string path = ImageAudioHolder.previousSceneName + "/Main" ;
        sprite = Resources.LoadAll<Sprite>(path); 
        helperObject = GameObject.FindGameObjectsWithTag("Helper");
        seeRecords = GameObject.Find("Records");
        seeRecords.SetActive(false);

        //** Finding Points Sprite for animation.Then stroing their name and making deactive **//
        //Point sprites are saved in Hierarchy as their value.
        //For example point sprite for 100points is saved as 100
        // After finding sprites , making them deactive until right button not pressed*//
        pointSprites = GameObject.FindGameObjectsWithTag("PointSprites");
        for(int i=0;i<12;i++) 
        {
            pointSpritesName[i] = pointSprites[i].name;
            pointSprites[i].SetActive(false);
        }
    }

    public void SpritenNameMaker()
    {
        //amader resource folder e rakha sprite gulor nam erokom : cat1,cat2,cat3,dog1,dog2,dog3
        //kintu sorce scene er nam erokom : Cat , Dog . Lowercasing apply korar por erokom: cat , dog
        //tai ei funnction e cat ke convert kora hoyeche . cat => cat1,cat2,cat3
        for(int i=0;i<3;i++)
        {
            sourceSpriteName[i] = sourceSceneName+(i+1).ToString();
        }
    }

    public void TestSpriteSelector()
    {
        int starIndex = 0;
        for (int i=0 ;i<sprite.Length;i++ )
        {
             if( (sprite[i].name==sourceSpriteName[0]) || (sprite[i].name==sourceSpriteName[1]) || (sprite[i].name==sourceSpriteName[2]) )
             {
                 testSprite[starIndex] = sprite[i];
                 notSelectingIndex[starIndex] = i;
                 starIndex++;
                 if(starIndex == 3) break;
             }    
        }
    }

    public void AudioInstruction()
    {
        string name = sourceSpriteName[0];
        name = name.Remove(name.Length-1 , 1);
        name = char.ToUpper(name[0]) + name.Substring(1) ;
        name = "AudioInstruction/" + name ;
        instruction = Resources.Load<AudioClip>(name);
        GameObject audioFolder = GameObject.Find("Ins");
        AudioSource audio =  audioFolder.GetComponent<AudioSource>();
        audio.clip = instruction;
    }

    public void RandomGeneratorDistractor()
    {
        string distractorName;
        int count = 0;
        int index;
        for (;;)
        {
            index = Random.Range(0,30);
            if( (index!=notSelectingIndex[0]) && (index!=notSelectingIndex[1]) && (index!=notSelectingIndex[2]) )
            {
                distractorSprite[count] = sprite[index];
                distractorName = sprite[index].name;
                for (int i=0;i<distractorName.Length;i++)
                {
                    if (distractorName[i] == '1' || distractorName[i] == '2' || distractorName[i] == '3') break;
                    else
                    {
                        distractorObjectName[count] += distractorName[i];
                        if(i==0) distractorObjectName[count] = distractorObjectName[count].ToUpper();
                    }
                }
                count++;
                if( count==2) break;
            }
        }
    }

    public void RandomGeneratorFinalSprite()
    {
        int index = Random.Range(0,3);
        finalSprite = testSprite[index];
    }

    public void ButtonFinder()
    {
        buttonObject = GameObject.FindGameObjectsWithTag("TestButton");
        for ( int i = 0 ; i < buttonObject.Length ; i++ )
        {
            button[i] = buttonObject[i].GetComponent<Button>();
            imageObject[i] = button[i].GetComponent<Image>();
        }
    }

    public void ImageSetter()
    {
        //**ei function er mul kaj holo 3 ta sprite(1:answer,2:distractor) ke amader practice scene er 3 ta button er opr boshiye deya**//

        testIndex = Random.Range(0,3);//answer sprite er jonnno randomly ekta button select kora hoyeche
        imageObject[testIndex].sprite = finalSprite;//tarpor shei button er upor answer sprite ta boshiye deya hoyeche
        rightButton = button[testIndex];//right button k store kore rakha hoyeche
        
        //right button charao onno dui button er jonno sprite set kora hoyeche
        if (testIndex == 0)
        {
             imageObject[1].sprite = distractorSprite[0];
             imageObject[2].sprite = distractorSprite[1]; 
        }
        else if(testIndex == 2)
        {
            imageObject[1].sprite = distractorSprite[0]; 
            imageObject[0].sprite = distractorSprite[1]; 
        }
        else
        {
            imageObject[0].sprite = distractorSprite[0]; 
            imageObject[2].sprite = distractorSprite[1]; 
        }
    }

    public int CalculatePoints()
    {
        //Calculates the final score of the player
        score = 100;
        int seconds = int.Parse(timerObject[0].GetComponent<Text>().text);
        int minutes = int.Parse(timerObject[1].GetComponent<Text>().text);
        if(numberOfAttempts == 1) score -= 0;
        else if(numberOfAttempts == 2) score -= 20;
        else if(numberOfAttempts == 3) score -= 40;
        else score -= 60;
        if (minutes==0 && seconds<10) score -= 0;
        else if (minutes==0 && seconds<20) score -= 15;
        else score -= 30; 
        Debug.Log(ImageAudioHolder.score);
        ImageAudioHolder.score += score;
        //pointBox.GetComponent<Text>().text = (score+ImageAudioHolder.score).ToString();
        return score;
    }

    public void StartAnimation(int score)
    {
        //the game has 12 diffrent possible points and for each point , it has a animation . SO THERE ARE 12 DIFFRENT ANIMATIONS !!
        for(int i = 0;i<12;i++)
        {
            //animation names are saved according to the point i.e. for point 100 there is an animation which is named as 100 . the below if block checks which animation to
            //display by matching the score.
            if(pointSpritesName[i] == score.ToString())
            {
                animationIndex = i;
                pointSprites[animationIndex].SetActive(true);
                destroyAnimator = true;
            }
        }
    }

    public void SaveStates()
    {
        string fileName = "/" + sourceSceneName + ".csv" ;
        filePath = Application.dataPath + fileName;
        StreamWriter writer = new StreamWriter(filePath,true);
        string distractors = "(";
        for (int i=0 ; i<distractorsSelected.Count ; i++)
        {
            distractors += distractorsSelected[i];
            distractors += "," ;
        }
        distractors += ")" ;
        string record = sourceSceneName + "_" + numberOfAttempts + "_" + distractors  + "_" +initialSeconds.ToString() + "seconds_" + System.DateTime.Now;
        writer.WriteLine(record);
        writer.Close();
    }
    
    public void Evaluation(Button selectedButton)
    {
        // if the correct option is selected
        if (selectedButton == rightButton) 
        {
            GameObject.Find("Smiley").GetComponent<Image>().enabled = true; // displays "smiley" emoji
            GameObject.Find("Clap").GetComponent<AudioSource>().Play(); // turns on "clap" audio clip
            activateTimer = false;
            int score = CalculatePoints();  // calling score calculator function
            StartAnimation(score);
            SaveStates();
            seeRecords.SetActive(true);
        } 
        //if not   
        else 
        {
            numberOfAttempts ++ ; // number of attempts are increased
            string temporaryName = "";
            string temporaryDistractorName = selectedButton.GetComponent<Image>().sprite.ToString() ;
            for(int i=0;i<temporaryDistractorName.Length;i++)
            {
                if(temporaryDistractorName[i] == '(') break;
                else temporaryName += temporaryDistractorName[i];
            }
            distractorsSelected.Add(temporaryName);
            GameObject.Find("Try_Again").GetComponent<Image>().enabled = true; // displays "Try Again" emoji
            GameObject.Find("Wrong").GetComponent<AudioSource>().Play(); // turns on "wrong" audio clip
            appearsEmoji = true;
        }    
    }

    public void EmojiHandler()
    {
        //this function disables the "Try Again" emoji after  0.5 seconds of execution
        if (appearsEmoji == true)
        {
            emojiTimer = 0f;
            appearsEmoji = false;
        }    
        else
        {    
            emojiTimer += Time.deltaTime;
            if(emojiTimer >= 0.5f)
            {
                //GameObject.Find("Smiley").GetComponent<Image>().enabled = false;
                GameObject.Find("Try_Again").GetComponent<Image>().enabled = false;
            }
        }
    }

    public void AppearHelper()
    {
        //this function handles the functionality of helper indication
        if(activateTimer == true)
        {
            if( ( ((int)(initialSeconds))%10 == 0 && (int)(initialSeconds)>0) || (initialSeconds == 0f && initialMinutes > 0f) ) 
            {
                helperObject[testIndex].GetComponent<Image>().enabled = true;
            }
            else helperObject[testIndex].GetComponent<Image>().enabled = false;
        }    
    }
    
    public void StopwatchFunctionalities()
    {
        //THis functions handles the operation of the stopwatch
        if (activateTimer == true)
        {
            if(initialSeconds >= 60f ) 
            {
                initialSeconds = 0f;
                initialMinutes += 1f;
                if (initialMinutes<10f) timerObject[1].GetComponent<Text>().text = "0" + ((int)initialMinutes).ToString();
                else timerObject[1].GetComponent<Text>().text = ((int)initialMinutes).ToString();
            }
            if (initialSeconds<10f) timerObject[0].GetComponent<Text>().text = "0" + ((int)initialSeconds).ToString();
            else timerObject[0].GetComponent<Text>().text = ((int)initialSeconds).ToString();
        }
        
    }

    public void DestroyAnimator()
    {
        // This fuction deactivates the animation after 1 second of execution
        if (destroyAnimator == true) 
        {
            animatorTime += Time.deltaTime;
            if(animatorTime >= 1f)pointSprites[animationIndex].SetActive(false);
        }    
    }
    
    public void GoBack()
    {
        SceneManager.LoadScene(ImageAudioHolder.previousSceneName);
    }
    public void RecordScene()
    {
        SceneManager.LoadScene("Data");
    }
    void Update()
    {
        initialSeconds += Time.deltaTime;
        AppearHelper();
        StopwatchFunctionalities();
        EmojiHandler();
        DestroyAnimator();
    }

    public void ListenInstruction()
    {
        GameObject audioFolder = GameObject.Find("Ins");
        AudioSource audioFIle = audioFolder.GetComponent<AudioSource>();
        audioFIle.Play();
    }
}
