using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager INSTANCE;
    public KeyCode leftKeyCode = KeyCode.A;
    public KeyCode rightKeyCode = KeyCode.D;
    public KeyCode jumpKeyCode = KeyCode.Space;
    public KeyCode attackDown = KeyCode.Mouse0;
    public KeyCode attackUp = KeyCode.Mouse1;
    public KeyCode dashKeyCode = KeyCode.LeftShift;

    public delegate void IntDelegate(int dir);
    public IntDelegate moveDelegate;

    public delegate void VoidDelegate();
    public VoidDelegate jumpDelegate;

    public VoidDelegate dashDelegate;

    private void Awake()
    {
        if (!INSTANCE)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        Move();
        Jump();
        Dash();
    }

    private void Move()
    {
        int dir = 0;
        bool left = Input.GetKey(leftKeyCode);
        bool right = Input.GetKey(rightKeyCode);
        if (left == right)
        {
            dir = 0;
        }
        else if (left)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        moveDelegate?.Invoke(dir);
    }

    private void Jump()
    {
        bool jump = Input.GetKeyDown(jumpKeyCode);
        if (jump)
        {
            jumpDelegate?.Invoke();
        }
    }

    private void Dash()
    {
        bool dash = Input.GetKeyDown(dashKeyCode);
        if (dash)
        {
            dashDelegate?.Invoke();
        }
    }


}
