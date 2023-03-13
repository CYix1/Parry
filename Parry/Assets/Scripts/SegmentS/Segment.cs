using System;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Vector3 _initialPosition;
    private bool _doMove;

    #region Start & Update

    private void Start()
    {
        _doMove = false;
        _initialPosition = transform.position;
    }

    void Update()
    {
        if (!_doMove) return;

        var pos = transform.position;
        transform.position = new Vector3(pos.x + speed, pos.y, pos.z);
    }

    #endregion

    public void SpawnAt(Vector3 position)
    {
        Debug.Log("Spawn " + this.name + " at " + position);
        transform.position = position;
        //StartMoving();
    }

    private void StartMoving()
    {
        _doMove = true;
    }

    public void Reset()
    {
        transform.position = _initialPosition;
        _doMove = false;
    }

    public Vector3 GetVectorWithXLength()
    {
        var scale = transform.localScale;
        var xScale = scale.x;
        return new Vector3(xScale, 0, 0);
    }
}