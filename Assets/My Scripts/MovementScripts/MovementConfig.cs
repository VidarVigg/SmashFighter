using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MovementConfig
{
    public float movementSpeed;
    public float jumpForce;
    public float gravityStrength;
    public int availableDoubleJumps;
    public float dashSpeed;
    public float dashDuration;
    public LayerMask layerMask;
}
