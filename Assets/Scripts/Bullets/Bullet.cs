using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] protected float _speed;

    protected void OnEnable()
    {
        Destroy(gameObject, 3f);
    }

    protected void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }
}
