using System;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(ShipMover))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(ShipShooter))]
public class Ship : MonoBehaviour
{
    private ScoreCounter _scoreCounter;
    private ShipMover _mover;
    private ShipShooter _shooter;
    private CollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _mover = GetComponent<ShipMover>();
        _handler = GetComponent<CollisionHandler>();
        _shooter = GetComponent<ShipShooter>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
        _shooter.AddPoints += AddScore;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
        _shooter.AddPoints -= AddScore;
    }

    private void ProcessCollision()
    {
        GameOver?.Invoke();
    }

    private void AddScore()
    {
        _scoreCounter.Add();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

}
