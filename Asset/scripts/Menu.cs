using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject control;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void empezar()
    {
        SceneManager.LoadScene(1);
    }
   
    public void salir()
    {
        Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
    public void vercontroles()
    {
        control.SetActive(true);
    }
    public void cerrar()
    {
        control.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
