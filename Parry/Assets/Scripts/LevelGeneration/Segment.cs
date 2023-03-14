using UnityEngine;

namespace LevelGeneration
{
    public class Segment : MonoBehaviour
    {
        public static float Speed = 0.05f;
        private Vector3 _initialPosition;
        private bool _doMove;

        #region Start & Update

        private void Start()
        {
            _doMove = true;
            _initialPosition = transform.position;
        }

        void Update()
        {
            if (!_doMove) return;

            var pos = transform.position;
            transform.position = new Vector3(pos.x + Speed, pos.y, pos.z);
        }

        #endregion

        public void Reset()
        {
            transform.position = _initialPosition;
            _doMove = false;
        }
    }
}