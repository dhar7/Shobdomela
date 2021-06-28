using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalsScript : MonoBehaviour
{
    public AudioSource Cat;
    public AudioSource Cow;
    public AudioSource Crocodile;
    public AudioSource Dog;
    public AudioSource Elephant;
    public AudioSource Fox;
    public AudioSource Giraffe;
    public AudioSource Goat;
    public AudioSource Horse;
    public AudioSource Lion;
    public AudioSource Monkey;
    public AudioSource Panda;
    public AudioSource Rabbit;
    public AudioSource Rat;
    public AudioSource Tiger;

    public string selectedObject;

    public bool[] objects = new bool[16]; //0-15
    public int selectedObjectIndex = 15;
    public float naturalScalingX = 0f;
    public float naturalScalingY = 0f;
    public GameObject prevHit ;
    public categoryScript script ;
    public void Object_handling2(int index,GameObject currentHit , float scalingX , float scalingY)
    {
        //1 . prev slected object should be returned to its natural scaling
        //prevHit.transform.localScale.x = naturalScalingX;
        //prevHit.transform.localScale.y = naturalScalingY;
        prevHit.transform.localScale = new Vector2(naturalScalingX, naturalScalingY);

        objects[selectedObjectIndex] = false;
        selectedObjectIndex = index;
        objects[selectedObjectIndex] = true;

        naturalScalingX = currentHit.transform.localScale.x;
        naturalScalingY = currentHit.transform.localScale.y;

        currentHit.transform.localScale = new Vector2(scalingX, scalingY);

        prevHit = currentHit;


        //2. store current selected object's scaling values
        //3. then just rescale it according to a given factor
    }
    /*void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Debug.Log(mousePos2D);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                selectedObject = hit.collider.gameObject.name;
                Debug.Log(selectedObject);
                if (selectedObject == "Cat")
                    script.Object_handling(0,hit.collider.gameObject,1.0f,1.0f,Cat);
                if (selectedObject == "Cow")
                    script.Object_handling(1, hit.collider.gameObject, 1.0f, 1.0f,Cow);
                if (selectedObject == "Crocodile")
                    script.Object_handling(2, hit.collider.gameObject, 1.0f, 1.0f,Crocodile);
                if (selectedObject == "Dog")
                    script.Object_handling(3, hit.collider.gameObject, 1.0f, 1.0f,Dog);
                if (selectedObject == "Elephant")
                    script.Object_handling(4, hit.collider.gameObject, 1.0f, 1.0f,Elephant);
                if (selectedObject == "Fox")
                    script.Object_handling(5, hit.collider.gameObject, 1.0f, 1.0f,Fox);
                if (selectedObject == "Giraffe")
                    script.Object_handling(6, hit.collider.gameObject, 1.0f, 1.0f,Giraffe);
                if (selectedObject == "Goat")
                    script.Object_handling(7, hit.collider.gameObject, 1.0f, 1.0f,Goat);
                if (selectedObject == "Horse")
                    script.Object_handling(8, hit.collider.gameObject, 1.0f, 1.0f,Horse);
                if (selectedObject == "Lion")
                    script.Object_handling(9, hit.collider.gameObject, 1.0f, 1.0f,Lion);
                if (selectedObject == "Monkey")
                    script.Object_handling(10, hit.collider.gameObject, 1.0f, 1.0f,Monkey);
                if (selectedObject == "Panda")
                    script.Object_handling(11, hit.collider.gameObject, 1.0f, 1.0f,Panda);
                if (selectedObject == "Rabbit")
                    script.Object_handling(12, hit.collider.gameObject, 1.0f, 1.0f,Rabbit);
                if (selectedObject == "Tiger")
                    script.Object_handling(13, hit.collider.gameObject, 1.0f, 1.0f,Tiger);
                if (selectedObject == "Rat")
                    script.Object_handling(14, hit.collider.gameObject, 1.0f, 1.0f,Rat);



            }
        }
    }*/
}
