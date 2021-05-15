using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public GameObject BulletToSpawn;
    public Transform BulletSpawnLocation;
    public Vector3 BulletStartingVelocity;
    [SerializeField]
    private float aggroRange;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float attackRange;
    private float attackTimer;
    [SerializeField]
    private float attackTimerShootTime;
    private float distanceToTarget;
    [SerializeField]
    private Stat commonChance;
    [SerializeField]
    private Stat uncommonChance;
    [SerializeField]
    private Stat rareChance;
    [SerializeField]
    private Stat epicChance;
    [SerializeField]
    private Stat legendaryChance;
    private GameObject HeroTarget;
    private NavMeshAgent myAgent;
    [SerializeField]
    private GameManagerScript gameManagerScriptReference;
    [SerializeField]
    private Stat lootDropChance;
    // Start is called before the first frame update
    void Awake()
    {
        HeroTarget = FindObjectOfType<Hero>().gameObject;
        myAgent = this.GetComponent<NavMeshAgent>();
        myAgent.stoppingDistance = attackRange;
        myAgent.speed = moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (HeroTarget != null)
        {
            this.transform.LookAt(new Vector3(HeroTarget.transform.position.x,
                HeroTarget.transform.position.y + 0.5f,
                HeroTarget.transform.position.z));

            distanceToTarget = Vector3.Distance(this.transform.position,
                                             HeroTarget.transform.position);
            if (distanceToTarget <= aggroRange)
            {
                myAgent.SetDestination(HeroTarget.transform.position);

            }
            if (distanceToTarget <= attackRange && attackTimer >= attackTimerShootTime)
            {
                attackTimer = 0f;
                SpawnProjectile(BulletToSpawn, BulletSpawnLocation, this.transform.forward);
            }
        }
    }
    public override void Die()
    {
        int randomNumber = Random.Range(0, 100);
        if(randomNumber <= lootDropChance.getStat())
        {
            gameManagerScriptReference.AddChestToList(commonChance.getStat(),
                                    uncommonChance.getStat(),
                                    rareChance.getStat(),
                                    epicChance.getStat(),
                                    legendaryChance.getStat());
            gameManagerScriptReference.PrintChest();
        }
        base.Die();
        Destroy(this.gameObject);
    }
}
