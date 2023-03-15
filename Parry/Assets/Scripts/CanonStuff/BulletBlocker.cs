using UnityEngine;

namespace CanonStuff
{
    // destroys bullets when hit
    // for obstacles in front of canons
    public class BulletBlocker : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}