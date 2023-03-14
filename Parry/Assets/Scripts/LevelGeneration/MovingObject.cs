using UnityEngine;

namespace LevelGeneration
{
    // for any object that is instantiated and starts moving immediately
    // moves towards POSITIVE X
    public class MovingObject : MonoBehaviour
    {
        // can be set by the instantiated object
        public static float Speed = 0.05f;
        private bool _reversed;
        
        void Update()
        {
            // store position to shorten code and avoid querying the same component more than once
            var pos = transform.position;
            // move object each frame by speed in x direction
            var newPos = GetNewXPos();
            transform.position = new Vector3(newPos, pos.y, pos.z);
        }

        private float GetNewXPos()
        {
            var xPos = transform.position.x;
            var speed = _reversed ? -Speed : Speed;
            return xPos + speed * Time.deltaTime;
        }

        public void ReverseDirection()
        {
            _reversed = !_reversed;
        }
    }
}