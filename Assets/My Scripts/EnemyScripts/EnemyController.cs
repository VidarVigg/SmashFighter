using UnityEngine;

public class EnemyController 
{
    public Vector2 CalculatedHeading(Vector2 aimPoint, Vector2 position, EnemyData data)
    {
        Vector2 dir = aimPoint - position;
        data.Heading = dir;
        return data.Heading;
    }
}
