using UnityEngine;

public class RangerShooter : Shooter
{
    [SerializeField] private Bullet _prefab;

    public override void Shoot()
    {
        Instantiate(_prefab, _shootPosition.position, _shootPosition.rotation);
    }
}
