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
    [SerializeField] private Tower _tower;
    private float _timeAfterShoot;
    private bool canShoot = true;

    private void Start()
    {
        _tower.SizeUpdated += StopGameYouWin;
        _tower.DamageUpdate += StopGameYouFail;
    }

    // Update is called once per frame
    void Update()
    {
        _timeAfterShoot += Time.deltaTime;

      
        if (canShoot == true & Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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


    private void StopGameYouWin(int levelsCount)
    {
        if (levelsCount == 0)
        {
            canShoot = false;
        }
    }


    private void StopGameYouFail(int damages)
    {
        if (damages == _tower._defeats)
        {
            canShoot = false;
        }
    }

}
