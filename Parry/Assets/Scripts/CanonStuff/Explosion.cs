using System.Collections;
using UnityEngine;

namespace CanonStuff
{
    public class Explosion : MonoBehaviour
    {
        public GameObject prefab;
        public Quaternion standardRotation = Quaternion.Euler(Vector3.forward);


        public void StartExplosion(Vector3 pos)
        {
            StartCoroutine(OnExplode(pos));
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
    }
}