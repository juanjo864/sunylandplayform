using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class monedas : MonoBehaviour
{

    private int moneda;
    [SerializeField] private TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
     
        moneda = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="monedas")
        {
            moneda += 25;
            texto.text = moneda.ToString();
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
