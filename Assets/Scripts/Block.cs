using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof (MeshRenderer))] 

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyFX;
    private MeshRenderer meshRenderer;

    //Событие когда в Block попадает Bullet
    public event UnityAction<Block> BulletHit;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    public void SetColor(Color color)
    {
        meshRenderer.material.color = color;
    }


    public void Break()
    {
        BulletHit?.Invoke(this);

        //вызов Particles Effect
        Instantiate(_destroyFX, transform.position, _destroyFX.transform.rotation);

        //Вызов Particles Effects и перекраска частиц в цвет блока
        //ParticleSystemRenderer fxRenderer = Instantiate(_destroyFX, transform.position, _destroyFX.transform.rotation).GetComponent<ParticleSystemRenderer>();
        //fxRenderer.material.color = meshRenderer.material.color;

        Destroy(gameObject);
    }




}
