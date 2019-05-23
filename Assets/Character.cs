using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig config = new CharacterConfig();
    [SerializeField] private CharacterData data = new CharacterData();

    private void Awake()
    {
        MovementManager movementManager = GetComponent<MovementManager>();

        if (!movementManager)
        {
            return;
        }

        movementManager.directionDelegate += Rotation;
    }

    private void Rotation(int value)
    {
        data.Direction = value;
    }

    public CharacterData Data
    {
        get { return data; }
    }

}
