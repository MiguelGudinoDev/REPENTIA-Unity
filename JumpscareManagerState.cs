using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareManagerState : MonoBehaviour
{
    [SerializeField] Game gameManager;
    [SerializeField] State stateObjetivo;
    [SerializeField] string escenaDestino = "hola";
    [SerializeField] float tiempoEspera = 7f;

    bool iniciado = false;

    void Update()
    {
        if (iniciado) return;

        if (gameManager != null && gameManager.GetCurrentState() == stateObjetivo)
        {
            iniciado = true;
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene(escenaDestino);
    }
}
