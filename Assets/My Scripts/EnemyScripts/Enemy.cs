using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyData enemyData = new EnemyData();
    [SerializeField] private EnemyController enemyController = new EnemyController();
    [SerializeField] private EnemyConfig enemyConfig = new EnemyConfig();
    public BoxCollider2D col;
    public RaycastHit2D[] hits = new RaycastHit2D[0];
    public EnemyController Controller
    {
        get { return enemyController; }
    }
    public EnemyData EnemyData
    {
        get { return enemyData; }
    }

    private void Start()
    {
        enemyData.state = EnemyData.EnemyState.idle;
        enemyData.Rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        if (enemyData.state == EnemyData.EnemyState.idle && gameObject != null && enemyData.HitLayer != 8)
        {
            //enemyData.Rb.velocity = (new Vector2(0, -800f)* Time.deltaTime);
            //enemyController.TravelTowardsPlayer(transform.position, Data.Attacker.transform.position, enemyData.Rb);
        }
    }
    public IEnumerator EnemyIsHitRoutine()
    {
        Debug.Log(enemyData.state);
        enemyData.Rb.velocity = enemyData.Heading.normalized * 3000 * Time.deltaTime;
        //Debug.Log(enemyData.Rb.velocity); // felet är att yledet blir negativt
        yield return new WaitForSeconds(0.3f);
        while (enemyData.state == EnemyData.EnemyState.hit)
        {
            RayCastForHitResult();
            if (enemyData.state == EnemyData.EnemyState.hit && enemyData.HitLayer == enemyData.EnemyDeathLayer)
            {
                enemyData.state = EnemyData.EnemyState.idle;
                enemyData.Rb.velocity = Vector2.zero;
                if (gameObject != null)
                {
                    Destroy(gameObject);
                }
                yield break;
            }
            yield return null;
        }
    }
    // Temporary code below
    private void RayCastForHitResult()
    {
        RaycastHit2D[] hits = new RaycastHit2D[4];
        hits[0] = Physics2D.Raycast(transform.position, Vector3.up, 0.5f, enemyConfig.Lm);
        hits[1] = Physics2D.Raycast(transform.position, Vector3.up * (-1), 0.5f, enemyConfig.Lm);
        hits[2] = Physics2D.Raycast(transform.position, Vector3.left, 0.5f, enemyConfig.Lm);
        hits[3] = Physics2D.Raycast(transform.position, Vector3.left * (-1), 0.5f, enemyConfig.Lm);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider != null)
            {
                enemyData.HitLayer = hits[i].collider.gameObject.layer;
            }

        }
    }
}
