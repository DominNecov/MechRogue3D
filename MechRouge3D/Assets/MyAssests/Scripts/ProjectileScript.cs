using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float Damage;
    public float BulletSpeed;
    public bool HerosBullet = false;
    public DamageType damagetype;
    private float destroyTime = 5f;
    private float timerForDestroy;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            if (HerosBullet)
            {
                if (collision.gameObject.name != "Hero")
                {
                    collision.gameObject.GetComponent<Character>().TakeDamage(Damage, damagetype);
                    destroyProjectile();
                }
            }
            else
            {
                if (collision.gameObject.name == "Hero")
                {
                    collision.gameObject.GetComponent<Character>().TakeDamage(Damage, damagetype);
                    destroyProjectile();
                }
            }

        }

    }
    void Update()
    {
        timerForDestroy += Time.deltaTime;
        if(timerForDestroy >= destroyTime)
        {
            destroyProjectile();
        }
    }
    private void destroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
