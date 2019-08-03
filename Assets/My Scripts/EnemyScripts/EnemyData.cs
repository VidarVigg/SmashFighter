using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 heading;
    [SerializeField] const int enemyDeathLayer = 8;
    [SerializeField] private int hitLayer;
    public enum EnemyState { idle, hit };
    public EnemyState state;


    public Rigidbody2D Rb
    {
        get { return rb; }
        set { rb = value; }
    }
    public Vector2 Heading
    {
        get { return heading; }
        set { heading = value; }
    }
    public int EnemyDeathLayer
    {
        get { return enemyDeathLayer; }
    }
    public int HitLayer
    {
        get { return hitLayer; }
        set { hitLayer = value; }
    }
}

