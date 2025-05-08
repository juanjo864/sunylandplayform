using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour
{
    [SerializeField] private GameObject muerte;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            muerte.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
