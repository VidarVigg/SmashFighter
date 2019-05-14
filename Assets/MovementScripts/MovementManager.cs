using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private MovementConfig config = new MovementConfig();
    [SerializeField] private MovementData data = new MovementData();

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

        if (dir != 0)
        {
            data.lastDir = dir;
        }
        if (dir > 0)
        {
            data.objectRotation = Quaternion.identity;
            gameObject.transform.rotation = data.objectRotation;
        }
        else if (dir < 0)
        {
            data.objectRotation.y = 180;
            gameObject.transform.rotation = data.objectRotation;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.55f, config.layerMask);
        if (hit.collider != null)
        {
            if (movementState != MovementState.Jumping)
            {
                movementState = MovementState.Grounded;
                data.doubleJumpsLeft = config.availableDoubleJumps;





            }
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
        if(dashTimer == null)
        {
            dashTimer = StartCoroutine(DashTimer());
        }
    }
    private IEnumerator DashTimer()
    {
        data.outerHorizontalVelocity = config.dashSpeed * data.lastDir;
        yield return new WaitForSeconds(config.dashDuration);
        data.outerHorizontalVelocity = 0;
        dashTimer = null;
        yield break;
    }
}
