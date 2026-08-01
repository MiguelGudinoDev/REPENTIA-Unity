using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaConEnter : MonoBehaviour
{
    // Nombre de la escena a la que quieres ir
    public string nombreEscena = "NombreDeLaEscena";

    void Update()
    {
        // Detecta cuando se presiona Enter
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
