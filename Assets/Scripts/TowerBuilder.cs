using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class TowerBuilder : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private int _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] public float _blockHeigh;
    [SerializeField] private Color[] _colors;
    private List<Block> _blocks;



    // строим башню из блоков
    public List<Block> Build()
    {
        //инициализируем лиск _blocks
        _blocks = new List<Block>();

        //создаем переменную текущего положения блока (она будет постоянно перезаписываться при создании каждого нового блока)
        Transform currentPoint = _buildPoint;

        //строим башню в цикле
        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);

            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);

            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        //возвращает Лиск блоков
        return _blocks;
    }


    //Расчитывает положение блока по Y
    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + _block.transform.localScale.y * _blockHeigh, _buildPoint.position.z);
    }

    //Спавнит один блок башни
    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }


    public void OnSceneLoaded(LevelConfiguration argument)
    {
        _towerSize = argument.TowerSize;
    }
}
