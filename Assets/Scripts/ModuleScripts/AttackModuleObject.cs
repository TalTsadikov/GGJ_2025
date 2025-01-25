using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackModuleObject : ModuleObject
{
    [SerializeField] private int damage;
    [SerializeField] private float CooldownRate;
    [SerializeField] private int radius;
    [SerializeField] private GameObject projectile;
    [SerializeField] private AttackModule _attackModule;
    [SerializeField] private LayerMask _enemyLayerMask;
    private GameObject _tower;
    private float _attackRate;

    public void Start()
    {
        _tower = GameObject.FindGameObjectWithTag("Tower");
        Player.Instance.OnModuleAdded += (module) => SetProjectile(module as AttackModule);
    }

    public void SetProjectile(AttackModule attackModule)
    {
        if (attackModule == _attackModule)
        {
            switch (attackModule._moduleName)
            {
                case "Rosemary":
                    damage = attackModule.damage;
                    CooldownRate = attackModule.CooldownRate;
                    radius = attackModule.radius;
                    break;
                case "Sabertooth Tooth":
                    damage = attackModule.damage;
                    CooldownRate = attackModule.CooldownRate;
                    radius = attackModule.radius;
                    break;
            }
        }
    }

    public void ProjectileSpawn()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(_tower.transform.position, 1000f, _enemyLayerMask);

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemiesInRange)
        {
            float distanceToEnemy = Vector2.Distance(_tower.transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.gameObject;
            }
        }

        if (closestEnemy != null)
        {
            GameObject proj = Instantiate(projectile, _tower.transform.position, _tower.transform.rotation);

            Vector2 directionToEnemy = (closestEnemy.transform.position - _tower.transform.position).normalized;

            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();

            rb.AddForce(directionToEnemy * 15f, ForceMode2D.Impulse);

           //float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
           //rb.rotation = angle;

            _attackRate = Time.time;

            Projectile p = proj.GetComponent<Projectile>();
            p.SetDamage(damage);
        }
    }

    public override void Update()
    {
        base.Update();

        if (_isPlaced && CanAttack())
        {
            ProjectileSpawn();
        }
    }

    private bool CanAttack()
    {
        return Time.time >= _attackRate + CooldownRate;
    }
}
