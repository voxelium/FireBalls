using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _bounceForce = 1000;
    [SerializeField] private float _bounceRadius = 5;
    [SerializeField] private float _bounceUpwords = 1.2f;
    [SerializeField] private float _timeForDestroy = 2;
    private Vector3 _moveDirection;
    private Tower tower;
    private bool canCollide = true;

    // Start is called before the first frame update
    void Start()
    {
        _moveDirection = Vector3.forward;

        tower = FindObjectOfType<Tower>();

        Destroy(gameObject, _timeForDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        //перемещение пули с заданной скоростью
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }


    // вызывается когда происходит Триггер столкновение с Block
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            tower.PlayAudioBlockDamaged();
            //Debug.Log("пуля попала в блок");

            // вызывает метод понижения положения башни
            tower.LowerTheTower();
            Destroy(gameObject);
        }

        //Столкновение с препятствием
        if (other.TryGetComponent(out Obstacle obstacle) & canCollide == true)
        {
            Bounce();
            tower.DamageCounting();
            canCollide = false;
        }

    }


    //Метод отскакивания от препятствия
    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        _speed = 0;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;

        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, 0, 1), _bounceRadius, _bounceUpwords);

    }

}
