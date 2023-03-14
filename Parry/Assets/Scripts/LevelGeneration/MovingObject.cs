using UnityEngine;

namespace LevelGeneration
{
    // for any object that is instantiated and starts moving immediately
    // moves towards POSITIVE X
    public class MovingObject : MonoBehaviour
    {
        // can be set by the instantiated object
        public static float Speed = 0.05f;

        #region Start & Update

        void Update()
        {
            // store position to shorten code and avoid querying the same component more than once
            var pos = transform.position;
            // move object each frame by speed in x direction
            transform.position = new Vector3(pos.x + Speed, pos.y, pos.z);
        }

        #endregion
    }
}