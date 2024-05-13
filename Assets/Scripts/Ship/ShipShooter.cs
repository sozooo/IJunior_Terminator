using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : Shooter
{
    [SerializeField] private AllyBullet _allyBulletPrefab;
    [SerializeField] private KeyCode _shootKey = KeyCode.Z;

    private List<AllyBullet> _allyBullets;

    public event Action AddPoints;

    private void Start()
    {
        _allyBullets = new List<AllyBullet>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            Shoot();
        }
    }

    private void RemoveBullet(AllyBullet allyBullet)
    {
        _allyBullets.Find(x => x == allyBullet).RangerShooted -= AddPoints;
        _allyBullets.Find(x => x == allyBullet).Destroyed -= RemoveBullet;

        _allyBullets.Remove(allyBullet);
    }

    public override void Shoot()
    {
        _allyBullets.Add(Instantiate(_allyBulletPrefab, _shootPosition.position, _shootPosition.rotation));

        _allyBullets.Last().RangerShooted += AddPoints;
        _allyBullets.Last().Destroyed += RemoveBullet;
    }

}
