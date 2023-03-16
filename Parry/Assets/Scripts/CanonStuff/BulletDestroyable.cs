
using System;
using LevelGeneration;
using UnityEngine;
using System.Collections;

namespace CanonStuff
{
    // object that can be destroyed by a bullet
    public class BulletDestroyable : MonoBehaviour
    {
        public GameObject prefab;
        private Quaternion standardRotation = Quaternion.Euler(Vector3.up*90);
        


        private void OnTriggerEnter(Collider other)
        {
            // only destroy on bullets that were deflected
            if (!IsBullet(other)) return;
            if (!WasDeflected(other)) return;

            // destroy both bullet and canon + play explosion
            Destroy(other.gameObject);
            StartCoroutine(OnExplode(transform.position));
            Destroy(gameObject);
        }
        
        private IEnumerator OnExplode(Vector3 pos, Quaternion? rotation = null)
        {
            GameObject clone;
            if (rotation == null)
            {
                clone = Instantiate(prefab, pos, standardRotation);
            }
            else
            {
                clone = Instantiate(prefab, pos, (Quaternion) rotation);
            }

            yield return new WaitForSeconds(0.95f);
            Destroy(clone);
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