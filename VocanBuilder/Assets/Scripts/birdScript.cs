using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public AudioSource magpie;
    public AudioSource kingfisher;
    public AudioSource parrot;
    public AudioSource dove;
    public AudioSource crow;
    public AudioSource ostrich;
    public AudioSource peacock;
    public AudioSource sparrow;
    public AudioSource goose;
    public AudioSource eagle;
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
    /*void Update()
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
                if (selectedObject == "Magpie")
                    script.Object_handling(0, hit.collider.gameObject, 1.7f, 1.8f, magpie);
                if (selectedObject == "Kingfisher")
                    script.Object_handling(1, hit.collider.gameObject, 1.6f, 1.7f, kingfisher);
                if (selectedObject == "Parrot")
                    script.Object_handling(2, hit.collider.gameObject, 0.8f, 0.8f, parrot);
                if (selectedObject == "Dove")
                    script.Object_handling(3, hit.collider.gameObject, 1.9f, 1.9f, dove);
                if (selectedObject == "Crow")
                    script.Object_handling(4, hit.collider.gameObject, 0.89f, 0.89f, crow);
                if (selectedObject == "Ostrich")
                    script.Object_handling(5, hit.collider.gameObject, 1.12f, 1.12f, ostrich);
                if (selectedObject == "Peacock")
                    script.Object_handling(6, hit.collider.gameObject, 0.8f, 0.9f, peacock);
                if (selectedObject == "Sparrow")
                    script.Object_handling(7, hit.collider.gameObject, 1.2f, 1.2f, sparrow);
                if (selectedObject == "Goose")
                    script.Object_handling(8, hit.collider.gameObject, 1.93f, 1.93f, goose);
                if (selectedObject == "Eagle")
                    script.Object_handling(9, hit.collider.gameObject, 1.1f, 1.17f, eagle);
           


            }
        }
    }*/
}

