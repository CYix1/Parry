using System.Collections;
using UnityEngine;

namespace CanonStuff
{
    public class Explosion : MonoBehaviour
    {
        public GameObject prefab;
        public Quaternion standardRotation = Quaternion.Euler(Vector3.forward);


        public void StartExplosion()
        {
            gameObject.SetActive(true);
            StartCoroutine(OnExplode(transform.position));
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