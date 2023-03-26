using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class canvas_GameOver : MonoBehaviour

{
    //[SerializeField] private TMP_Text txtTMP;
    [SerializeField] private Tower _tower;
    [SerializeField] private Canvas _canvas;


    // Start is called before the first frame update
    void Start()
    {
        _canvas.enabled = false;
        _tower.DamageUpdate += PrintGameOver;

    }

    private void PrintGameOver(int count)
    {
        if (count == _tower._defeats)
        {
            _canvas.enabled = true;
        }
        
    }




}
