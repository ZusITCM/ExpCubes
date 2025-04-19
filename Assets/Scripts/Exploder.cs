using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 1f;

    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.Spawned += Explode;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= Explode;
    }

    private void Explode(Cube cube)
    {
        cube.Rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }
}
