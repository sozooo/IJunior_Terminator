using System;
using UnityEngine;

public class AllyBullet : Bullet
{
    public event Action RangerShooted;
    public event Action<AllyBullet> Destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ranger>(out Ranger ranger))
        {
            RangerShooted?.Invoke();
        }
    }

    protected void OnDestroy()
    {
        Destroyed?.Invoke(gameObject.GetComponent<AllyBullet>());
    }
}
