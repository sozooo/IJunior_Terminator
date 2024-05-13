using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Transform _shootPosition;

    public abstract void Shoot();
}
