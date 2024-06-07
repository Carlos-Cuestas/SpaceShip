using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menup : MonoBehaviour
{
    // Start is called before the first frame update
    public string Scena = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiasescena()
    {
        SceneManager.LoadScene(Scena);
    }

    public void salir(){
        Application.Quit();
    }
}
