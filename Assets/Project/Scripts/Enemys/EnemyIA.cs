using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyIA : LifeController
{
    public static EnemyIA instance;

    [Header("Movement System")]
    [SerializeField] protected float speed;
    [SerializeField] protected float stoppingDistance;

    [Header("Attack System")]
    public float attackDamage;
    [SerializeField] protected float attackRange;
    [SerializeField] private float attackRate;
    private float attackTime;
    private bool pointDestroyed;

    [Header("Components")]
    [SerializeField] private Animator anim;
    private NavMeshAgent agent;


    private Vector3 destiny;
    private bool isFinished;

    protected virtual void Awake()
    {
        instance = this;

        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Start()
    {
        base.Start();

        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;

        destiny = transform.position;
    }

    protected virtual void Update()
    {
        Animations();
        Move();

        if (isFinished && !isDeath && Point.instance.gameObject.activeSelf) Attack();

        if (!Point.instance.gameObject.activeSelf) pointDestroyed = true;
    }

    protected virtual void Attack()
    {
        if (Time.time < attackTime) return;

        attackTime = Time.time + 1 / attackRate;
        anim.SetTrigger("Attack");
    }

    private void Move()
    {
        if (isDeath) return;

        destiny = Point.instance.transform.position;
        agent.SetDestination(destiny);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !isFinished)
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                isFinished = true;
    }

    private void Animations()
    {
        if (agent.velocity.magnitude > 0.1f)
            anim.SetFloat("MoveSpeed", 1f);
        else
            anim.SetFloat("MoveSpeed", 0f);

        anim.SetBool("IsDeath", isDeath);
        anim.SetBool("PointDestroyed", pointDestroyed);
    }
}