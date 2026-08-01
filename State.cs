using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/State")]
public class State : ScriptableObject
{
    [TextArea(14, 10)]
    [SerializeField] string StoryText;

    [SerializeField] State[] nextStates;

    [Header("imagen y sfx")]
    [SerializeField] Sprite sprite;
    [SerializeField] AudioClip music;

    [Header("sonidito pipipi")]
    [SerializeField] AudioClip typeSound;
    [SerializeField] int soundFrequency = 1;

    public AudioClip GetTypeSound() => typeSound;
    public int GetSoundFrequency() => soundFrequency;

    [Header("texto")]
    [SerializeField] Color textColor = Color.white;
    [SerializeField] float typingSpeed = 0.02f;

    internal bool activado;

    [SerializeField] InputType inputType;

    public InputType GetInputType()
    {
        return inputType;
    }

    public string GetStateStoryText() => StoryText;
    public State[] GetNextStates() => nextStates;
    public Sprite GetSprite() => sprite;
    public AudioClip GetMusic() => music;

    public enum InputType
    {
        MultipleChoice,
        ContinueOnly    
    }

    public Color GetTextColor() => textColor;
    public float GetTypingSpeed() => typingSpeed;
}