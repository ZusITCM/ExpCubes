using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [field: SerializeField] public float SplitChance { get; private set; } = 1;

    private Material _material;

    private readonly float _chanceDevider = 2;
    private readonly float _scaleDevider = 2;

    public event Action<Cube> Splitting;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;

        SplitChance = 1;
    }

    private void OnMouseUpAsButton()
    {
        if (Random.value <= SplitChance)
            Splitting?.Invoke(this);

        Destroy(gameObject);
    }

    public void Init(float splitChance)
    {
        Rigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
        Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        SplitChance = splitChance / _chanceDevider;

        transform.localScale /= _scaleDevider;

        _material.color = Random.ColorHSV();
    }
}
