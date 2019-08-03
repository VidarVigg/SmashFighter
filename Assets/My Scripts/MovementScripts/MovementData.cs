using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MovementData
{
    public bool grounded;
    public float verticalVelocity;
    public float horizontalVelocity;
    public float outerVerticalVelocity;
    public float outerHorizontalVelocity;
    public int attackDir;
    public int doubleJumpsLeft;
    public Vector2 playerScreenPoint;






    public Quaternion objectRotation;// test
    
}
