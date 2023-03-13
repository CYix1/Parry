using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float jumpStrength = 100f;
    private Rigidbody body;

    private void Awake()
    {
        body = this.GetComponent<Rigidbody>();
    }

    public void OnMove()
    {
        float dir = playerInput.actions.FindAction("Move").ReadValue<float>();
        transform.position = new Vector3(dir, transform.position.y, transform.position.z);
    }

    public void OnJump()
    {
        body.AddForce(new Vector3(0f, jumpStrength, 0f));
    }

    public void OnDodge()
    {
        StartCoroutine(DodgeEnumerator());
    }

    IEnumerator DodgeEnumerator()
    {
        transform.localScale = new Vector3(1f, 0.5f, 1f);
        yield return new WaitForSecondsRealtime(1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
