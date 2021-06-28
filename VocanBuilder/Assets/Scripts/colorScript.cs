using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorScript : MonoBehaviour
{
    public AudioSource black;
    public AudioSource blue;
    public AudioSource skyblue;
    public AudioSource purple;
    public AudioSource white;
    public AudioSource green;
    public AudioSource red;
    public AudioSource orange;
    public AudioSource pink;
    public AudioSource yellow;
    public string selectedObject;

    public bool[] objects = new bool[11]; //0-15
    public int selectedObjectIndex = 11;
    public float naturalScalingX = 0f;
    public float naturalScalingY = 0f;
    public GameObject prevHit;
    public categoryScript script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            Debug.Log(mousePos2D);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject.name;
                Debug.Log(selectedObject);
                //if (selectedObject == "Black")
                    //script.Object_handling(0, hit.collider.gameObject, 1.4f, 1.6f, black);
                //if (selectedObject == "Blue")
                    //script.Object_handling(1, hit.collider.gameObject, 1.4f, 1.4f, blue);
                //if (selectedObject == "Skyblue")
                    //script.Object_handling(2, hit.collider.gameObject, 0.57f, 0.57f, skyblue);
                //if (selectedObject == "Purple")
                    //script.Object_handling(3, hit.collider.gameObject, 1.5f, 1.3f, purple);
                //if (selectedObject == "White")
                    //script.Object_handling(4, hit.collider.gameObject, 1.6f, 1.8f, white);
                //if (selectedObject == "Green")
                    //script.Object_handling(5, hit.collider.gameObject, 1.6f, 1.4f, green);
                //if (selectedObject == "Red")
                    //script.Object_handling(6, hit.collider.gameObject, 1.4f, 1.4f, red);
                //if (selectedObject == "Orange")
                    //script.Object_handling(7, hit.collider.gameObject, 1.3f, 1.4f, orange);
                //if (selectedObject == "Pink")
                    //script.Object_handling(8, hit.collider.gameObject, 1.4f, 1.5f, pink);
                //if (selectedObject == "Yellow")
                    //script.Object_handling(9, hit.collider.gameObject, 1.4f, 1.4f, yellow);



            }
        }
    }
}

