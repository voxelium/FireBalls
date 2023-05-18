using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class canvas_YouWin : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Canvas _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _canvas.enabled = false;
        //_tower.SizeUpdated += PrintWin;
    }


    private void PrintWin(int levelscount)
    {
        if (levelscount == 0)
        {
            _canvas.enabled = true;
        }
    }

}
