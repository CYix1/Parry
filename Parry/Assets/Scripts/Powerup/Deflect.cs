using LevelGeneration;
using UnityEngine;

namespace Powerup
{
    public class Deflect : MonoBehaviour
    {
        public int numberOfDeflects = 3;
        private FlashRed _flasher;

        private void Start()
        {
            _flasher = GetComponent<FlashRed>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!CanBeDeflected(other)) return;

            // handle bullet
            var moveComponent = other.GetComponent<MovingObject>();
            Debug.Log(moveComponent);
            moveComponent.ReverseDirection();

            // handle shield
            _flasher.Flash();
            numberOfDeflects--;
            if (numberOfDeflects <= 0) Destroy(gameObject);
        }

        private bool CanBeDeflected(Collider other)
        {
            return other.CompareTag("Bullet");
        }
    }
}