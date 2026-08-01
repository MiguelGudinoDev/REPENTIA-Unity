using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] GameObject imageObject;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TypewriterStateText typewriter;

    Image imageComponent;

    State stateRef;
    [SerializeField] State startingState;

    void Start()
    {
        stateRef = startingState;
        imageComponent = imageObject.GetComponent<Image>();
        UpdateState();
    }

    void Update()
    {
        ManageStates();
    }

    void ManageStates()
    {
        State[] nextStates = stateRef.GetNextStates();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stateRef = nextStates[0];
            UpdateState();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            stateRef = nextStates[1];
            UpdateState();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stateRef = nextStates[2];
            UpdateState();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (typewriter.IsTyping())
            {
                typewriter.CompleteTextInstantly();
                return;
            }

            stateRef = nextStates[3];
            UpdateState();
        }
    }

    void UpdateState()
    {
        typewriter.ShowState(stateRef);

        // Cambiar sprite
        imageComponent.sprite = stateRef.GetSprite();

        // Música
        audioSource.clip = stateRef.GetMusic();
        audioSource.Play();
    }

    public State GetCurrentState()
    {
        return stateRef;
    }
}