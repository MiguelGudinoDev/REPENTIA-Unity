using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Game");
        }
        //cambioDeEscena();
    }
    //public void cambioDeEscena()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        SceneManager.LoadScene("Game");
    //    }
    //}
}
