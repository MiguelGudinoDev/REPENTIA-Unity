using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterStateText : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;

    [Header("Sound")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip typeSound;
    [SerializeField] int soundFrequency = 1;

    Coroutine typingCoroutine;
    bool isTyping;
    string currentText;

    public bool IsTyping()
    {
        return isTyping;
    }

    public void CompleteTextInstantly()
    {
        if (!isTyping) return;

        textComponent.maxVisibleCharacters = currentText.Length;
        isTyping = false;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
    }

    public void ShowState(State state)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        textComponent.color = state.GetTextColor();
        typingCoroutine = StartCoroutine(TypeText(state));
    }

    IEnumerator TypeText(State state)
    {
        currentText = state.GetStateStoryText();
        float delay = state.GetTypingSpeed();
        AudioClip stateSound = state.GetTypeSound();
        int frequency = state.GetSoundFrequency();

        textComponent.text = currentText;
        textComponent.maxVisibleCharacters = 0;

        int counter = 0;
        isTyping = true;

        while (textComponent.maxVisibleCharacters < currentText.Length)
        {
            textComponent.maxVisibleCharacters++;
            counter++;

            if (audioSource != null && stateSound != null && counter % frequency == 0)
            {
                audioSource.PlayOneShot(stateSound);
            }

            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
    }
}
// me voy a pegar un tiro mashallah si no funciona esto, no se como hacer un typewriter effect y me esta costando un huevo, ya llevo 3 horas intentando y nada, no se que mierda estoy haciendo mal, ya no se que mas probar, estoy a punto de tirar todo a la mierda y dedicarme a otra cosa, esto es una pesadilla, no entiendo nada, no se como hacer que el texto aparezca letra por letra, ya intente mil cosas y nada funciona, estoy desesperado, necesito ayuda urgente, esto es un infierno, no puedo creer que algo tan simple me este dando tanto problema, ya no se que mas hacer, estoy al borde del colapso nervioso, por favor alguien ayúdeme antes de que pierda la cabeza.