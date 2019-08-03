using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class MovementManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private MovementConfig config = new MovementConfig();
    [SerializeField] private MovementData data = new MovementData();
    public delegate void DirectionDelegate(int direction);
    public DirectionDelegate directionDelegate;

    public delegate void AttackDirDelegate(int attackDir);
    public AttackDirDelegate attackDirDelegate;

    

    public MovementData Data
    {
        get { return data; }
    }

    [System.Serializable]
    public enum MovementState
    {
        Grounded,
        Jumping,
        Falling,
    }
    public MovementState movementState;

    public enum MovementDirection
    {
        Left,
        Right,
    }
    public MovementDirection movementDirection;

    private Rigidbody2D rb;
    private Coroutine dashTimer;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Character character = GetComponent<Character>();
    }

    private void Start()
    {

        InputManager inputManager = InputManager.INSTANCE;

        if (inputManager == null)
        {
            return;
        }

        inputManager.moveDelegate += Move;
        inputManager.jumpDelegate += Jump;
        inputManager.dashDelegate += Dash;
        inputManager.mouseAttackPositionDelegate += MousePositionCheck;

        gameObject.transform.rotation = data.objectRotation;
    }

    private void Update()
    {
        GroundCheck();
        Gravity();
        rb.velocity = new Vector2(data.horizontalVelocity + data.outerHorizontalVelocity, data.verticalVelocity + data.outerVerticalVelocity);
    }

    public void Move(int dir)
    {

        if (dir != 0 && dir != data.attackDir)
        {
            data.attackDir = dir;
            directionDelegate?.Invoke(dir);
        }
        data.horizontalVelocity = dir * config.movementSpeed;
    }

    public void Jump()
    {
        if (movementState != MovementState.Grounded)
        {
            if (data.doubleJumpsLeft <= 0)
            {
                return;
            }
            data.doubleJumpsLeft--;
        }
        data.verticalVelocity = config.jumpForce;
        movementState = MovementState.Jumping;
    }

    public void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, config.layerMask);
        if (hit.collider != null)
        {
            if (movementState != MovementState.Jumping)
            {
                movementState = MovementState.Grounded;
                data.doubleJumpsLeft = config.availableDoubleJumps;
            }
        }
    }

    public void MousePositionCheck()
    {
        data.playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (Input.mousePosition.x < data.playerScreenPoint.x)
        {
            attackDirDelegate.Invoke(-1);
            //Debug.Log("Left");
        }
        else if (Input.mousePosition.x > data.playerScreenPoint.x)
        {
            attackDirDelegate.Invoke(1);
            //Debug.Log("Right");
        }
    }

    public void Gravity()
    {
        if (movementState != MovementState.Grounded)
        {
            data.verticalVelocity -= config.gravityStrength * Time.deltaTime;
            if (movementState == MovementState.Jumping)
            {
                if (data.verticalVelocity < 0)
                {
                    movementState = MovementState.Falling;
                }
            }
        }
        else
        {
            data.verticalVelocity = -config.gravityStrength * Time.deltaTime;
        }
    }

    public void Dash()
    {
        if (dashTimer == null)
        {
            dashTimer = StartCoroutine(DashTimer());
        }
    }
    private IEnumerator DashTimer()
    {
        data.outerHorizontalVelocity = config.dashSpeed * data.attackDir;
        yield return new WaitForSeconds(config.dashDuration);
        data.outerHorizontalVelocity = 0;
        dashTimer = null;
        yield break;
    }
}
