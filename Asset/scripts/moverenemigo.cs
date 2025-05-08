using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverenemigo : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D enemy;
    [SerializeField] private Transform lineas;
    private float velocidad = 1.0f,distancia=1.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
      Vector2 newPosition = enemy.position + new Vector2(velocidad * Time.fixedDeltaTime, 0); 
        enemy.MovePosition(newPosition);
        RaycastHit2D hit = Physics2D.Raycast(lineas.position, Vector2.down, distancia); 
        if (hit.collider == null) { 
            girar(); 
        }


    }

    private void girar()
    {
        transform.Rotate(0f, 180f, 0f);
        velocidad = -velocidad;
      
    }
    private void giro(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstaculo"))
        {
            girar();
        }
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        giro(collision.collider);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        giro(collision);
    }
}
