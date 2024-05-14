using UnityEngine;

[RequireComponent(typeof(RangerShooter))]
public class Ranger : MonoBehaviour, IInteractable
{
    [SerializeField] private float _shootCooldown;
    [SerializeField] private CollisionHandler _handler;

    private RangerShooter _shooter;
    private ObjectPool _pool;
    private float _currentTime;

    private void Awake()
    {
        _shooter = GetComponent<RangerShooter>();
    }

    private void Start()
    {
        _pool = GetComponentInParent<Container>().Pool;
    }

    private void OnEnable ()
    {
        _handler.CollisionDetected += Dead;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= Dead;
    }

    private void Update()
    {

        if(_currentTime >= _shootCooldown)
        {
            _shooter.Shoot();

            _currentTime = 0;
        }

        _currentTime += Time.deltaTime;
    }

    public void Dead()
    {
        _pool.PutObject(this);
    }
}
