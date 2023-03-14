using UnityEngine;

// disables material when in play mode
public class DebugCollider : MonoBehaviour
{
    private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = false;
    }
}
