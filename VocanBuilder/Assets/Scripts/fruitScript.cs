using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitScript : MonoBehaviour
{
    public AudioSource mango;
    public AudioSource jackfruit;
    public AudioSource apple;
    public AudioSource guava;
    public AudioSource banana;
    public AudioSource litchi;
    public AudioSource orange;
    public AudioSource grape;
    public AudioSource blackberry;
    public AudioSource pineapple;
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
                

            }
        }
    }

}

