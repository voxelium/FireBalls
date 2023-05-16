using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_StartGame : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    private void Update()
    {
        
        //if (Input.GetMouseButtonDown(0))
        //{
        //    audioSource.Play();
        //}
    }


}
