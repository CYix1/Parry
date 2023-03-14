using UnityEngine;

// fires a bullet every "shotInterval"
public class Canon : MonoBehaviour
{
    [SerializeField] private float shotInterval = 1f;
    [SerializeField] private Transform bullet;

    private Vector3 _spawnPos;

    private void Start()
    {
        // spawn bullet at canons pos
        _spawnPos = transform.position;
        
        // calls Shoot every shotInterval
        InvokeRepeating(nameof(Shoot), shotInterval, shotInterval);
    }

    private void Shoot()
    {
        Instantiate(bullet, _spawnPos, Quaternion.identity);
    }
}