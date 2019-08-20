using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponController controller = new WeaponController();
    [SerializeField] private WeaponData data = new WeaponData();

    public WeaponController Controller
    {
        get { return controller; }
    }

    Character character;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
        data.weaponSprite = GetComponentInChildren<SpriteRenderer>();
        data.weaponCollider = GetComponent<BoxCollider2D>();
        ControllWeaponColliderAndVisuals(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.tag == "Enemy")
            {

                data.direction = character.Data.Direction;
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.transform.rotation = Quaternion.identity;
                data.launchCoordinate = controller.GetCoordinateByRaycast(data, transform, character.ActiveAttack);
                enemy.Controller.CalculateRagdollHeading(data.launchCoordinate, collision.transform.position, enemy.EnemyData);
                enemy.EnemyData.state = EnemyData.EnemyState.hit;
                StartCoroutine(enemy.EnemyIsHitRoutine());

            }
        

    }

    public void ControllWeaponColliderAndVisuals(bool onOrOff)
    {
        data.weaponCollider.enabled = onOrOff;
        data.weaponSprite.enabled = onOrOff;
    }
}
