using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;

    public Transform ShootPosition => _shootPosition;

    public abstract void Shoot();
}
