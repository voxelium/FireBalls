using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class txt_DamageCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtDamageCount;
    [SerializeField] private Tower _tower;

    // Start is called before the first frame update
    void Start()
    {
        _txtDamageCount.text = "0";
        _tower.DamageUpdate += PrintDamageCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PrintDamageCount(int count)
    {
        _txtDamageCount.text = count.ToString();
    }

}
