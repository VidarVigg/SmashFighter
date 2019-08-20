using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public int direction;
    public Vector2 launchCoordinate;
    public LayerMask layerMask;
    public GameObject rayOrigin;
    public RaycastHit2D hit;
    public SpriteRenderer weaponSprite;
    public BoxCollider2D weaponCollider;
    public bool hasBeenTriggered;
}
