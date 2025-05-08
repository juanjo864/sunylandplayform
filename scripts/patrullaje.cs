using System.Collections;
using UnityEngine;

public class patrullaje : MonoBehaviour
{
    public Transform[] puntos;
    private Animator anim;
    private Rigidbody2D enemy;
    private int puntoActual = 0;
    public float velocidad = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<Rigidbody2D>();
        StartCoroutine(mover());
    }
    IEnumerator mover()
    {
        while (true)
        {
            if (puntos.Length == 0)
            {
                yield break;
            }
            Transform objetivo = puntos[puntoActual];
            while (Vector2.Distance(enemy.position, objetivo.position) > 0.1f)
            {
                Vector2 nuevaPosicion = Vector2.MoveTowards(enemy.position, objetivo.position, velocidad * Time.deltaTime);
                enemy.MovePosition(nuevaPosicion);
                yield return null;
            }
            Vector2 direccion = (Vector2)puntos[(puntoActual + 1) % puntos.Length].position - enemy.position; 
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg; enemy.rotation = angulo;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
