using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private float _speed;
    private Vector3 _moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _moveDirection = Vector3.forward;
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
            Destroy(gameObject);

            // вызывает методе понижение положения башни, но понижение не происходит, хотя метод вызывается
            //tower.LowerTheTower();
        }
    }

}
