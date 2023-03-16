using UnityEngine;

// checks if player is in range and shoots only if so
// stops shooting if player has passed canon
namespace CanonStuff
{
    public class RangeCheckerCanon : MonoBehaviour
    {
        private Canon _canon;

        private void Start()
        {
            _canon = GetComponentInParent<Canon>();
            Debug.Log("canon = " + _canon.name);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsPlayer(other)) return;

            _canon.StartShooting();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsPlayer(other)) return;

            _canon.StopShooting();
        }

        #region Tag Checks

        private bool IsPlayer(Collider other)
        {
            return other.CompareTag("Player");
        }

        #endregion
    }
}