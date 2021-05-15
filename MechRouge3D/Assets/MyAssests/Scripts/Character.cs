using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stat Health;
    public Stat MaxHealth;
    public Stat Shield;
    public Stat MaxShield;
    public Stat Damage;
    public Stat BulletSpeed;
    public Stat PhysicalDefence;
    public Stat ExplosiveDefence;
    public Stat EnergyDefence;
    public float damageAfterDefence;
    [SerializeField]
    private DamageType damage_type;

    private void Start()
    {
        
    }
    
    public void TakeDamage(float damagetaken, DamageType typeofdamage)
    {
        switch (typeofdamage)
        {
            case DamageType.Energy:
                damageAfterDefence = damagetaken - EnergyDefence.getStat();
                if (damageAfterDefence < 0)
                {
                    damageAfterDefence = 0f;
                }
                Health.subtractStat(damageAfterDefence);
                if(Health.getStat() <= 0)
                {
                    Die();
                }
                break;
            case DamageType.Explosive:
                damageAfterDefence = damagetaken - ExplosiveDefence.getStat();
                if (damageAfterDefence < 0)
                {
                    damageAfterDefence = 0f;
                }
                Health.subtractStat(damageAfterDefence) ;
                if (Health.getStat() <= 0)
                {
                    Die();
                }
                break;
            case DamageType.Physical:
                damageAfterDefence = damagetaken - PhysicalDefence.getStat();
                if (damageAfterDefence < 0)
                {
                    damageAfterDefence = 0f;
                }
                Health.subtractStat(damageAfterDefence);
                if (Health.getStat() <= 0)
                {
                    Die();
                }
                break;
        }
    }
    public void SpawnProjectile(GameObject projectiletospawn, Transform projectilespawnlocation, Vector3 velocitydirection)
    {
        GameObject projectile = Instantiate(projectiletospawn, projectilespawnlocation.position, Quaternion.identity);
        if (this.gameObject.name == "Hero")
        {
            projectile.GetComponent<ProjectileScript>().HerosBullet = true;
        }
        projectile.GetComponent<ProjectileScript>().Damage = Damage.getStat();
        projectile.GetComponent<ProjectileScript>().damagetype = damage_type;
        projectile.GetComponent<Rigidbody>().velocity = velocitydirection * BulletSpeed.getStat();

    }
    public virtual void Die()
    {

    }
}
