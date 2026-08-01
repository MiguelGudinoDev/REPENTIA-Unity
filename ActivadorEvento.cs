using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivadorEvento : MonoBehaviour
{
    public EventoVisualSonido evento;
    public Image uiImagen;
    public AudioSource audioSource;

    public void ActivarEvento()
    {
        if (evento == null) return;

        // Mostrar imagen
        uiImagen.sprite = evento.imagen;

        // Reproducir sonido
        audioSource.PlayOneShot(evento.sonido);
    }
}