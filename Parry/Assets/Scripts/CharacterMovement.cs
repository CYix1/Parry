
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] perrys;
    

    public enum Activity
    {
        RUNNING, JUMPING, DODGING, JETPACK
    }

    private Rigidbody body;
    public Activity activity;
    private float lanePos;

    [SerializeField] private float jumpStrength = 5f;
    [SerializeField] private float moveSpeed = 10f;

    private readonly float minMovePos = -3f;
    private readonly float maxMovePos = 3f;
    private float startPos ;
    private void Awake()
    {
        body = this.GetComponent<Rigidbody>();
        startPos = transform.position.x;
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
            transform.position = new Vector3(startPos, transform.position.y, newPos);
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
        foreach (var parry in perrys)
        {
            parry.SetActive(false);
        }
        perrys[1].SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        foreach (var parry in perrys)
        {
            parry.SetActive(false);
        }
        perrys[0].SetActive(true);

        activity = Activity.RUNNING;
    }
}
