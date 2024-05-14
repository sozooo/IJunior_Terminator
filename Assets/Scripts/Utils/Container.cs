using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    public ObjectPool Pool => _pool;
}
