using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            CollisionDetected?.Invoke();
        }
    }
}
