using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAudioSource : MonoBehaviour
{
    [Header("Referencia al Game (MUY IMPORTANTE)")]
    [SerializeField] private Game gameManager;

    [Header("Estado que destruye")]
    [SerializeField] private State destroyState;
    [SerializeField] private GameObject objectToDestroy;

    [Header("Estado que activa")]
    [SerializeField] private State activateState;
    [SerializeField] private GameObject objectToActivate;

    private State lastState;

    private void Update()
    {
        if (gameManager == null) return;

        State currentState = gameManager.GetCurrentState();

        if (currentState != lastState)
        {
            lastState = currentState;

            // Destruir
            if (currentState == destroyState && objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }

            // Activar
            if (currentState == activateState && objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}