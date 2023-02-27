using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stat Health;
    public Stat MaxHealth;
    public Stat Shield;
    public Stat MaxShield;
    public Stat PhysicalDamage;
    public Stat EnergyDamage;
    public Stat ExplosiveDamage;
    public Stat BulletSpeed;
    public Stat PhysicalDefence;
    public Stat ExplosiveDefence;
    public Stat EnergyDefence;
    public List<Stat> AllStatsForItems = new List<Stat>();
    [SerializeField]
    private DamageType damage_type;

    private void Start()
    {
        
    }
    
    public void TakeDamage(float damagetaken, DamageType typeofdamage)
    {
        float damageAfterDefence;
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
        switch (damage_type)
        {
            case DamageType.Physical:
                projectile.GetComponent<ProjectileScript>().Damage = PhysicalDamage.getStat();
                break;
            case DamageType.Energy:
                projectile.GetComponent<ProjectileScript>().Damage = EnergyDamage.getStat();
                break;
            case DamageType.Explosive:
                projectile.GetComponent<ProjectileScript>().Damage = ExplosiveDamage.getStat();
                break;        
        }
        projectile.GetComponent<ProjectileScript>().damagetype = damage_type;
        projectile.GetComponent<Rigidbody>().velocity = velocitydirection * BulletSpeed.getStat();
    }
    public void UpdateStats()
    {
        AllStatsForItems.Add(MaxHealth);
        AllStatsForItems.Add(MaxShield);
        AllStatsForItems.Add(PhysicalDamage);
        AllStatsForItems.Add(ExplosiveDamage);
        AllStatsForItems.Add(EnergyDamage);
        AllStatsForItems.Add(BulletSpeed);
        AllStatsForItems.Add(PhysicalDefence);
        AllStatsForItems.Add(ExplosiveDefence);
        AllStatsForItems.Add(EnergyDefence);
    }
    public virtual void Die()
    {

    }
    public Stat GetRandomStat()
    {

        int randomNum = Random.Range(0, AllStatsForItems.Count);
        return AllStatsForItems[randomNum];
    }
}
