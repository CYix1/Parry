using LevelGeneration;
using UnityEngine;

public class Deflect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!CanBeDeflected(other)) return;

        var moveComponent = other.GetComponent<MovingObject>();
        moveComponent.ReverseDirection();
    }

    private bool CanBeDeflected(Collider other)
    {
        return other.CompareTag("Deflectable");
    }
}
