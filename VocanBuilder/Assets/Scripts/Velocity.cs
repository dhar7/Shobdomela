using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    float xValue , yValue;
    
    
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        xValue = Random.Range(-40,40);
        yValue = Random.Range(-40,40);
        rigidBody2D.velocity = new Vector2 ( xValue,yValue);
        
        
    }

    void Update()
    {
         
    }

    
}
