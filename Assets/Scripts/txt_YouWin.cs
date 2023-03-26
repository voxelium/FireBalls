using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class txt_YouWin : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtWin;
    [SerializeField] private Tower _tower;

    // Start is called before the first frame update
    void Start()
    {
        _txtWin.enabled = false;
        _tower.SizeUpdated += PrintWin;
    }


    private void PrintWin(int levelscount)
    {
        if (levelscount == 0)
        {
            _txtWin.enabled = true;
        }
    }

}
