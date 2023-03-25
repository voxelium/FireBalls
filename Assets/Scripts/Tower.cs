using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent (typeof (TowerBuilder))]

public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private float blockHeigh;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdated;
    

    // Start is called before the first frame update
    void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        blockHeigh = _towerBuilder._blockHeigh;
        _blocks = _towerBuilder.Build();

        //евент передает количество блоков на старте игры
        SizeUpdated?.Invoke(_blocks.Count);

        //подписывает все блоки на ивент OnBulletHit
        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

    }



    private void OnBulletHit(Block hittedBlock)
    {
        hittedBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(hittedBlock);

        //евент передает количество блоков после каждого уничтожения блока
        SizeUpdated?.Invoke(_blocks.Count);

    }



    // Понижает башню
    public void LowerTheTower()
    {
        //понижает башню через VS - сохранить как пример отправки запуска Custom Event из C#
        //CustomEvent.Trigger(gameObject, "LowerMe");

        transform.position = new Vector3 (transform.position.x, transform.position.y - blockHeigh, transform.position.z);

    }


}
