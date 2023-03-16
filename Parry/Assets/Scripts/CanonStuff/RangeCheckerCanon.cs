using UnityEngine;

// checks if player is in range and shoots only if so
namespace CanonStuff
{
    public class RangeCheckerCanon : MonoBehaviour
    {
        private BoxCollider _collider;
        private Canon _canon;

        private void Start()
        {
            InitCanon();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(gameObject.name + " entered collider.");
            if (!IsPlayer(other)) return;

            _canon.StartShooting();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsPlayer(other)) return;

            _canon.StopShooting();
        }

        #region Init

        private void InitCanon()
        {
            _canon = GetComponentInParent<Canon>();
        }

        #endregion

        #region Tag Checks

        private bool IsPlayer(Collider other)
        {
            return other.CompareTag("PlayerRB");
        }

        #endregion
    }
}