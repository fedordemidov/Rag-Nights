using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : ArtificialIntelligence
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool walking, chaseing;
    [SerializeField] private Transform target;

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        Following(target, 1.5f);
    }
}
