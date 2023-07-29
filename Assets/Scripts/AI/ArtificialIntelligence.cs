using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArtificialIntelligence : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float speed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Following(Transform target, float speedModifire)
    {
        agent.speed = speed * speedModifire;
        agent.SetDestination(target.position);
    }
}