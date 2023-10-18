using Assets.Scripts.GameLogic.UnitAction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    private Attack _attack;
    private Chase _chase;

    //Attacking
    public float timeBetweenAttacks;
    //States
    public float sightRange, attackRange;

    private void Awake()
    {
        InitUnitAction();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void InitUnitAction()
    {
        _attack = new Attack();
        _chase = new Chase();
    }


}
