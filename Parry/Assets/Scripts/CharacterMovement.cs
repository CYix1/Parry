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
    private Activity activity;
    private float lanePos;

    [SerializeField] private float jumpStrength = 5f;
    [SerializeField] private float moveSpeed = 10f;

    private readonly float minMovePos = -3f;
    private readonly float maxMovePos = 3f;

    private void Awake()
    {
        body = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float curPos = transform.position.z;
        if (curPos != lanePos)
        {
            float dir = Mathf.Sign(lanePos - curPos);
            float maxMove = moveSpeed * dir * Time.fixedDeltaTime;
            float newPos = Mathf.Clamp(curPos + maxMove, minMovePos, maxMovePos);
            if (lanePos == 0 && Mathf.Sign(newPos) != Mathf.Sign(curPos))
            {
                newPos = 0;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, newPos);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lanePos = Mathf.Clamp(lanePos + context.ReadValue<float>(), minMovePos, maxMovePos);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && activity == Activity.RUNNING)
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
        if (context.performed && activity == Activity.RUNNING)
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
