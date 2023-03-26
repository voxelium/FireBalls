using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class txtTowerLevels : MonoBehaviour
{

    [SerializeField] private TMP_Text _txtTowerLevels;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdated += PrintTextUpdated;

    }


    private void OnDisable()
    {
        _tower.SizeUpdated -= PrintTextUpdated;
    }


    //присваивает объекту текст значение levelsCount
    private void PrintTextUpdated(int levelsCount)
    {
        _txtTowerLevels.text = levelsCount.ToString();
    }





}
