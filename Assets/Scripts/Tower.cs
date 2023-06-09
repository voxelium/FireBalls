using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent (typeof (TowerBuilder))]
[RequireComponent(typeof(AudioSource))]

public class Tower : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [Header("___")]
    [SerializeField] public int _defeats = 3;
    private TowerBuilder _towerBuilder;
    private float blockHeigh;
    private List<Block> _blocks;
    private int towerStartSize;
    private int damageCount = 0;


    public event UnityAction<int> SizeUpdated;
    public event UnityAction<int> DamageUpdate;

    // Start is called before the first frame update
    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        blockHeigh = _towerBuilder._blockHeigh;
        _blocks = _towerBuilder.Build();

        //евент передает количество блоков
        SizeUpdated?.Invoke(_blocks.Count);

        towerStartSize = _blocks.Count;

        //евент передает количество попаданий к игрока
        DamageUpdate?.Invoke(damageCount);

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

    public void DamageCounting()
    {
        damageCount ++ ;

        DamageUpdate?.Invoke(damageCount);

    }


    // Понижает башню
    public void LowerTheTower()
    {
        //понижает башню через VS - сохранить как пример отправки запуска Custom Event из C#
        //CustomEvent.Trigger(gameObject, "LowerMe");

        transform.position = new Vector3 (transform.position.x, transform.position.y - blockHeigh, transform.position.z);

    }


    public void PlayAudioBlockDamaged()
    {
        audioSource.volume = 0.1f;
        audioSource.clip = audioClip;
        audioSource.Play();

    }

}
