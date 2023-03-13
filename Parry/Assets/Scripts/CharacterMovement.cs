using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private MainInput input;
    public float moveSpeed=5f;
    public float jumpStrength = 10f;
    void Awake()
    {
        input = new MainInput();
    }

    private void Update()
    {
        Vector2 move = input.Character.move.ReadValue<Vector2>();
        if (move != Vector2.zero)
        {
            transform.Translate(move*moveSpeed*Time.deltaTime);
        }

       /* DONT USE THIS
         bool pressedJumped = input.Character.jump.IsPressed();
        if (pressedJumped)
        {
            transform.Translate(transform.position+ new Vector3(0,jumpStrength,0) );
        }
        */
    }

    private void OnDisable()
    {
        
        input.Disable();
    }
    private void OnEnable()
    {
        
        input.Enable();
    }

}
