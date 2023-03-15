using UnityEngine;

// checks if player is in range and shoots only if yes
namespace CanonStuff
{
    public class RangeCheckerCanon : MonoBehaviour
    {
        [SerializeField] private float laneWidth = 9;
        [SerializeField] private float playerRange = 10;

        private BoxCollider _collider;
        private Canon _canon;

        private void Start()
        {
            InitColliderSize();
            InitCanon();
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

        #region Init

        private void InitColliderSize()
        {
            _collider = GetComponent<BoxCollider>();

            var scale = _collider.transform.localScale;
            Vector3 laneSize = new Vector3(playerRange, 6, laneWidth);

            _collider.transform.localScale = laneSize;
        }

        private void InitCanon()
        {
            _canon = GetComponentInParent<Canon>();
        }

        #endregion

        #region Tag Checks

        private bool IsPlayer(Collider other)
        {
            return other.CompareTag("Player");
        }

        #endregion
    }
}