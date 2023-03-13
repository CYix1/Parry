using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private bool _doMove = false;

    void Update()
    {
        if (!_doMove) return;

        var pos = transform.position;
        transform.position = new Vector3(pos.x + speed, pos.y, pos.z);
    }

    public void SpawnAt(Vector3 position)
    {
        transform.position = position;
        
    }

    public void StartMoving()
    {
        _doMove = true;
    }
}