using UnityEngine;

public class EnemyController 
{
    public Vector2 CalculateRagdollHeading(Vector2 rayCollisionPoint, Vector2 enemyPosition, EnemyData data)
    {
        Vector2 dir = rayCollisionPoint - enemyPosition;
        data.Heading = dir;
        return data.Heading;
    }
    public void TravelTowardsPlayer(Vector2 enemyPosition, Vector2 playerPosition, Rigidbody2D rb)
    {
        Vector2 heading = enemyPosition - playerPosition;
        rb.velocity = heading;
    }
}