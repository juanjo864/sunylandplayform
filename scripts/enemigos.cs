using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemigos : MonoBehaviour
{
    private Rigidbody2D enemy;
    private Animator anim;
    private float fuerza = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemy=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
           Rigidbody2D rg=collision.GetComponent<Rigidbody2D>();
            if (rg!=null)
            {
                rg.AddForce(Vector3.up * fuerza, ForceMode2D.Impulse);
            }
            Destroy(gameObject);
            anim.SetBool("muerte",true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
