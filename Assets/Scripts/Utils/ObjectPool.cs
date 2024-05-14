using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Ranger _prefab;

    private Queue<Ranger> _pool;

    private void Awake()
    {
        _pool = new Queue<Ranger>();
    }

    public Ranger GetObject()
    {
        if (_pool.Count == 0)
        {
            Ranger ranger = Instantiate(_prefab);
            ranger.transform.parent = _container;

            return ranger;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Ranger ranger)
    {
        Debug.Log("hello");
        Debug.Log(ranger.ToString());
        _pool.Enqueue(ranger);
        ranger.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
