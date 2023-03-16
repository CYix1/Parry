using System;
using LevelGeneration;
using UnityEngine;

namespace CanonStuff
{
    // object that can be destroyed by a bullet
    public class BulletDestroyable : MonoBehaviour
    {
        [SerializeField] private Explosion explosion;

        private void Start()
        {
            explosion.gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            // only destroy on bullets that were deflected
            if (!IsBullet(other)) return;
            if (!WasDeflected(other)) return;

            // destroy both bullet and canon + play explosion
            Destroy(other.gameObject);
            explosion.StartExplosion();
            Destroy(gameObject);
        }

        #region Checks

        private bool IsBullet(Collider other)
        {
            return other.CompareTag("Bullet");
        }

        private bool WasDeflected(Collider other)
        {
            var bulletComp = other.GetComponent<MovingObject>();
            return bulletComp.WasReversed();
        }

        #endregion
    }
}