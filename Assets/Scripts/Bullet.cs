using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }
}
