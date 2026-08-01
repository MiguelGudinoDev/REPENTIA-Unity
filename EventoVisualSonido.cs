using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoEvento", menuName = "Eventos/EventoVisualSonido")]
public class EventoVisualSonido : ScriptableObject
{
    public Sprite imagen;
    public AudioClip sonido;
}