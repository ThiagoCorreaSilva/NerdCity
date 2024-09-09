using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyIA : MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;

    [Header("NavMesh Variables")]
    [SerializeField] private Animator anim;
    private NavMeshAgent agent;
    private Vector3 destiny;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start()
    {
        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;

        destiny = transform.position;
    }

    protected virtual void Update()
    {
        Animations();
        Move();
    }

    private void Move()
    {
        destiny = Point.instance.transform.position;
        agent.SetDestination(destiny);
    }

    private void Animations()
    {
        if (agent.velocity.magnitude > 0.1f)
            anim.SetFloat("MoveSpeed", 1f);
        else
            anim.SetFloat("MoveSpeed", 0f);
    }
}