using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetWeenShoots;
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        //if (Input.GetMouseButton(0))
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            if (_timeAfterShoot > _delayBetWeenShoots)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetWeenShoots/2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
        }


    }


    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);

    }

}
