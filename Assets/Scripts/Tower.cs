using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (TowerBuilder))]

public class Tower : MonoBehaviour
{

    private TowerBuilder _towerBuilder;
    private float blockHeigh;
    private List<Block> _blocks;

    // Start is called before the first frame update
    void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        blockHeigh = _towerBuilder._blockHeigh;
        _blocks = _towerBuilder.Build();


        //Вроде как подписывает все блоки на ивент OnBulletHit - плохая практика
        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

    }

    private void OnBulletHit(Block hittedBlock)
    {
        hittedBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(hittedBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y * blockHeigh, block.transform.position.z);
        }

    }


    //Должен Понижать башню, но почему-то не работает, хотя метод упешно вызывается пулей
    public void LowerTheTower()
    {
        Debug.Log("TEST");
        transform.position = transform.position - new Vector3 (transform.position.x, transform.position.y * blockHeigh, transform.position.z);

    }


}
