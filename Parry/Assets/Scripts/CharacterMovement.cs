using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    enum Activity
    {
        RUNNING, JUMPING, DODGING
    }

    private Rigidbody body;
    private PlayerInput playerInput;
    private Activity activity;
    private float lanePos;

    [SerializeField] private float jumpStrength = 5f;
    [SerializeField] private float moveSpeed = 10f;

    private void Awake()
    {
        body = this.GetComponent<Rigidbody>();
        playerInput = this.GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        float curPos = transform.position.x;
        if(curPos != lanePos)
        {
            transform.position = new Vector3(lanePos, transform.position.y, transform.position.z);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        lanePos = playerInput.actions.FindAction("Move").ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && activity == Activity.RUNNING)
        {
            StartCoroutine(JumpEnumerator());
        }
    }

    IEnumerator JumpEnumerator()
    {
        activity = Activity.JUMPING;
        body.velocity += new Vector3(0f, jumpStrength, 0f);
        while (body.velocity.y != 0 || body.position.y != 1)
        {
            yield return new WaitForEndOfFrame();
        }
        activity = Activity.RUNNING;
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.started && activity == Activity.RUNNING)
        {
            StartCoroutine(DodgeEnumerator());
        }
    }

    IEnumerator DodgeEnumerator()
    {
        activity = Activity.DODGING;
        transform.localScale = new Vector3(1f, 0.5f, 1f);
        yield return new WaitForSecondsRealtime(1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        activity = Activity.RUNNING;
    }
}
