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


    // Update is called once per frame
    void Update()
    {
        
    }
}
