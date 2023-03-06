using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public Stat FireRate;
    public Stat PhysicalDefence;
    public Stat ExplosiveDefence;
    public Stat EnergyDefence;
    public List<Stat> AllStatsForItemsOffensive = new List<Stat>();
    public List<Stat> AllStatsForItemsDeffensive = new List<Stat>();
    public List<ItemData> AllPotentialItems = new List<ItemData>();
    public Dictionary<string, Stat> AllStatsForItems = new Dictionary<string, Stat>();
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
        AllStatsForItems.Add(MaxHealth.StatName,MaxHealth);
        AllStatsForItems.Add(MaxShield.StatName,MaxShield);
        AllStatsForItems.Add(PhysicalDamage.StatName,PhysicalDamage);
        AllStatsForItems.Add(ExplosiveDamage.StatName,ExplosiveDamage);
        AllStatsForItems.Add(EnergyDamage.StatName,EnergyDamage);
        AllStatsForItems.Add(BulletSpeed.StatName,BulletSpeed);
        AllStatsForItems.Add(FireRate.StatName, FireRate);
        AllStatsForItems.Add(PhysicalDefence.StatName,PhysicalDefence);
        AllStatsForItems.Add(ExplosiveDefence.StatName,ExplosiveDefence);
        AllStatsForItems.Add(EnergyDefence.StatName,EnergyDefence);
        AllStatsForItemsDeffensive.Add(MaxHealth);
        AllStatsForItemsDeffensive.Add(MaxShield);
        AllStatsForItemsOffensive.Add(PhysicalDamage);
        AllStatsForItemsOffensive.Add(ExplosiveDamage);
        AllStatsForItemsOffensive.Add(EnergyDamage);
        AllStatsForItemsOffensive.Add(BulletSpeed);
        AllStatsForItemsOffensive.Add(FireRate);
        AllStatsForItemsDeffensive.Add(PhysicalDefence);
        AllStatsForItemsDeffensive.Add(ExplosiveDefence);
        AllStatsForItemsDeffensive.Add(EnergyDefence);
    }
    public virtual void Die()
    {

    }
    public Stat GetRandomStatOffensive()
    {
        int RandomInt = Random.Range(0, AllStatsForItemsOffensive.Count);
        return AllStatsForItemsOffensive[RandomInt];
    }
    public Stat GetRandomStatDeffensive()
    {
        int RandomInt = Random.Range(0, AllStatsForItemsDeffensive.Count);
        return AllStatsForItemsDeffensive[RandomInt];
    }
    public ItemData GetRandomItemFromList()
    {
        int RandomInt = Random.Range(0, AllPotentialItems.Count);
        return AllPotentialItems[RandomInt];
    }
    public Stat FindStatInDictonary (string KeyToFind)
    {
        return AllStatsForItems[KeyToFind];
    }
}
