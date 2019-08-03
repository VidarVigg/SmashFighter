using UnityEngine;

[System.Serializable]
public class CharacterConfig
{
    [SerializeField] private float hP;

    public float HP
    {
        get { return hP; }
    }
}
