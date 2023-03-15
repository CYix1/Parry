using System;
using LevelGeneration;
using UnityEngine;

namespace CanonStuff
{
    // object can be destroyed by a bullet
    //[RequireComponent(typeof(PlayExplosion))]
    public class BulletDestroyable : MonoBehaviour
    {
        //private PlayExplosion _playExplosion;
        
        private void Start()
        {
            //_playExplosion = GetComponent<PlayExplosion>();
        }

        private void OnTriggerEnter(Collider other)
        {
            // only destroy on bullets that were deflected
            if (!IsBullet(other)) return;
            if (!WasDeflected(other)) return;
            
            // destroy both bullet and canon
            Destroy(gameObject);
            Destroy(other.gameObject);
            
            // TODO: start explosion

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