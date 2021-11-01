using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Forward Speed")]
    [SerializeField, Range(2f, 100f)] public float speed;
    [SerializeField, Range(2f, 100f)] public float minSpeed;
    [SerializeField, Range(2f, 100f)] public float maxSpeed;
    [SerializeField, Range(0f, 4f)] private float speedStep;
    
    [Header("Horizontal speed")]
    [SerializeField, Range(2f, 100f)] public float horizontalSpeed;
    [SerializeField, Range(2f, 100f)] public float minHorizontalSpeed;
    [SerializeField, Range(2f, 100f)] public float maxHorizontalSpeed;
    [SerializeField, Range(0f, 4f)] private float horizontalSpeedStep;
    
    [Header("Jump")]
    [SerializeField, Range(2f, 100f)] public float jumpForce;
    
    [Space]
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public float deadYZone = -5f;
    [SerializeField] private float health;

    public void SetDamage(float damage)
    {
        health -= damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public void DecreaseSpeed()
    {
        speed = Math.Max(speed - speedStep, minSpeed);
        horizontalSpeed = Math.Min(horizontalSpeed - horizontalSpeedStep, minHorizontalSpeed);
    }

    public void IncreaseSpeed()
    {
        speed = Math.Min(speed + speedStep, maxSpeed);
        horizontalSpeed = Math.Min(horizontalSpeed + horizontalSpeedStep, maxHorizontalSpeed);
    }
}
