using LevelGeneration;
using UnityEngine;

// fires a bullet every "shotInterval"
namespace CanonStuff
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] private float shotInterval = 1f;
        [SerializeField] private float shotSpeed = 10f;
        [SerializeField] private Transform bullet;


        public void StartShooting()
        {
            // calls Shoot every shotInterval
            InvokeRepeating(nameof(Shoot), 0, shotInterval);
        }

        public void StopShooting()
        {
            // stop shooting if player has passed
            // CancelInvoke() stops all invoke calls on the gameObject
            CancelInvoke();
        }

        private void Shoot()
        {
            var bulletGo = Instantiate(bullet, transform.position, Quaternion.identity);
            var movObjComponent = bulletGo.GetComponent<MovingObject>();
            movObjComponent.SetSpeed(shotSpeed);
        }
    }
}