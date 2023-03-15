using UnityEngine;

namespace CanonStuff
{
    public class BulletDestroyable : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!IsBullet(collision)) return;
        
            Destroy(gameObject);
        }

        private bool IsBullet(Collision collision)
        {
            return collision.gameObject.CompareTag("Bullet");
        }
    }
}