using Assets.Scripts.GameLogic.UnitAction;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    //Attacking
    public float timeBetweenAttacks;
    //States
    public float attackRange;

    private Transform[] enemies;

    private Attack _attack;
    private Chase _chase;


    private void Awake()
    {
        InitUnitAction();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void InitUnitAction()
    {
        _attack = new Attack();
        _chase = new Chase();
    }

    IEnumerator GetNearestTarget()
    {
        float minDestance = float.MaxValue;
        Transform currentTarget = null;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (navMeshAgent.SetDestination(enemies[i].transform.position))
            {
                while (navMeshAgent.pathPending)
                {
                    yield return null;
                }
                if (navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid)
                {
                    Debug.Log("Impossible to reach the " + enemies[i].name);
                    break;
                }

                float pathDistance = 0;
                pathDistance += Vector3.Distance(transform.position, navMeshAgent.path.corners[0]);
                for (int j = 1; j < navMeshAgent.path.corners.Length; j++)
                {
                    pathDistance += Vector3.Distance(navMeshAgent.path.corners[j - 1], navMeshAgent.path.corners[j]);
                }
                if (minDestance > pathDistance)
                {
                    minDestance = pathDistance;
                    currentTarget = enemies[i];
                    navMeshAgent.ResetPath();
                }

            }

        }
        if (currentTarget != null)
        {
            navMeshAgent.SetDestination(currentTarget.transform.position);
            //...
        }
    }

}
