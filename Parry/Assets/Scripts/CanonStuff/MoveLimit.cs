using System;
using UnityEngine;

namespace CanonStuff
{
    // destroys itself after it has travelled "moveDistance" long
    public class MoveLimit : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
        private float _startX;

        private void Start()
        {
            _startX = transform.position.x;
        }

        private void Update()
        {
            if (HasReachedLimit())
            {
                Destroy(gameObject);
            }
        }

        private bool HasReachedLimit()
        {
            var distanceTravelled = Math.Abs(transform.position.x - _startX);
            return distanceTravelled >= moveDistance;
        }
    }
}