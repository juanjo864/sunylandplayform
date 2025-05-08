using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool jump=false;
    private monedas gemas;
    private Vector2 velocidaddelplayer = new Vector2();
    [SerializeField] private GameObject muerte;
    private float velocidadrebote = 3.0f;
    [Header("agacharse")]
    public bool agachar = false;
    public BoxCollider2D cuadrado;
    private Vector2 originalsize;
  
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gemas=new monedas();
        
     
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moverpersonaje = Input.GetAxisRaw("Horizontal");
        float agacharse = Input.GetAxisRaw("Vertical");
        velocidaddelplayer.Set(moverpersonaje * 3f, player.linearVelocity.y);
        player.linearVelocity = velocidaddelplayer;
        sprite.flipX = moverpersonaje < 0;
        anim.SetFloat("speed", Mathf.Abs(moverpersonaje));
      
        if (Input.GetButton("Jump") && !jump)
        {
            player.AddForce(Vector2.up*260f);
            jump = true;
            anim.SetBool("isjump",true);
          
        }
        if (agacharse < 0)
        {

            agachar = true;
            anim.SetBool("agacho", true);
            cuadrado.size = new Vector2(0.1860544f, 0.102545f);
            cuadrado.offset = new Vector2(-0.01465369f, -0.1087275f);
        }
        else
        {
            agachar = false;
            anim.SetBool("agacho", false);
            cuadrado.size = new Vector2(0.18137f, 0.2174244f);
            cuadrado.offset = new Vector2(-0.01151359f, -0.05128775f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("suelo"))
        {
            jump = false;
            anim.SetBool("isjump",false);
            player.linearVelocity = new Vector2(player.linearVelocity.x, 0);
        }
        if (collision.gameObject.CompareTag("enemigo"))
        {
            
        
            anim.SetTrigger("muerte");
            muerte.SetActive(true);
        
        }
        if (collision.gameObject.CompareTag("caida"))
        {
            anim.SetTrigger("muerte");
            muerte.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nivel2"))
        {
            SceneManager.LoadScene(2);

        }
        if (collision.CompareTag("Nivel3"))
        {
            SceneManager.LoadScene(3);
        }
        if (collision.CompareTag("Nivel4"))
        {
            SceneManager.LoadScene(4);
        }
        if (collision.CompareTag("Nivel5"))
        {
            SceneManager.LoadScene(5);
        }

    }

}
