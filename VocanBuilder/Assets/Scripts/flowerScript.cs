using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerScript : MonoBehaviour
{
    public AudioSource Champak;
    public AudioSource Chinarose;
    public AudioSource Jasmine;
    public AudioSource Lotus;
    public AudioSource Marigold;
    public AudioSource Rose;
    public AudioSource Waterlily;
    public AudioSource Sunflower;
    public AudioSource Tuberose;
    public AudioSource Tulip;
    public string selectedObject;
    public bool[] objects = new bool[12];
    public int selectedObjectIndex = 11;
    public float naturalScalingX = 0f;
    public float naturalScalingY = 0f;
    public GameObject prevHit;
    public categoryScript script;
        // Start is called before the first frame update
    //void Start()
    
    public void object_handling2(int index, GameObject currentHit, float scalingX,float scalingY)
    {
        Debug.Log("Called");
        prevHit.transform.localScale = new Vector2(naturalScalingX, naturalScalingY);
        objects[selectedObjectIndex] = false;
        selectedObjectIndex = index;
        objects[selectedObjectIndex] = true;
        naturalScalingX = currentHit.transform.localScale.x;
        naturalScalingY = currentHit.transform.localScale.y;
        currentHit.transform.localScale = new Vector2(scalingX, scalingY);
        prevHit = currentHit;
    }

    // Update is called once per frame
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
                if (selectedObject == "Champak")
                {
                    script.Object_handling(0, hit.collider.gameObject,1.3f,1.2f,Champak);
                }
                if (selectedObject == "China rose")
                {
                    script.Object_handling(1, hit.collider.gameObject, 0.6f, 0.6f,Chinarose);
                }
                if (selectedObject == "Jasmine")
                {
                    script.Object_handling(2, hit.collider.gameObject, 0.7f, 0.7f,Jasmine);
                }
                if (selectedObject == "Lotus")
                {
                    script.Object_handling(3, hit.collider.gameObject, 0.6f, 0.6f, Lotus);
                }
                if (selectedObject == "Marigold")
                {
                    script.Object_handling(4, hit.collider.gameObject, 0.7f, 0.7f, Marigold);
                }
                if (selectedObject == "Rose")
                {
                    script.Object_handling(5, hit.collider.gameObject, 0.8f, 0.9f, Rose);
                }
                if (selectedObject == "Water lily")
                {
                    script.Object_handling(6, hit.collider.gameObject, 0.7f, 0.7f, Waterlily);
                }
                if (selectedObject == "Sunflower")
                {
                    script.Object_handling(7, hit.collider.gameObject, 1.2f, 1.2f, Sunflower);
                }
                if (selectedObject == "Tuberose")
                {
                    script.Object_handling(8, hit.collider.gameObject, 0.7f, 0.7f, Tuberose);
                }
                if (selectedObject == "Tulip")
                {
                    script.Object_handling(9, hit.collider.gameObject, 0.7f, 0.7f, Tulip);
                }
            }
        }
        
    }*/
}
