using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _bounceForce = 500;
    [SerializeField] private float _bounceRadius = 5;
    [SerializeField] private float _bounceUpwords = 1.2f;
    private Vector3 _moveDirection;
    private Tower tower;

    // Start is called before the first frame update
    void Start()
    {
        _moveDirection = Vector3.forward;

        tower = FindObjectOfType<Tower>();
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

            // вызывает методе понижение положения башни, но понижение не происходит, хотя метод вызывается
            tower.LowerTheTower();

            Destroy(gameObject);
        }

       
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }

    }


    //Метод отскакивания от препятствия
    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        _speed = 0;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        //rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, 0, 1), _bounceRadius, _bounceUpwords, ForceMode.VelocityChange);

        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, 0, 1), _bounceRadius, _bounceUpwords);

    }

}
