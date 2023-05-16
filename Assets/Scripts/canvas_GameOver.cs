using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class canvas_GameOver : MonoBehaviour

{
    [SerializeField] private Tower _tower;
    [SerializeField] private Canvas _canvas;

    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;

        _canvas.enabled = false;
        _tower.DamageUpdate += PrintGameOver;

    }

    private void PrintGameOver(int count)
    {
        if (count == _tower._defeats)
        {
            audioSource.Play();
            _canvas.enabled = true;
        }
        
    }

}
