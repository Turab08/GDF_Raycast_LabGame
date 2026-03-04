using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIRaycastAll : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chasing,
    }

    private EnemyState currentState = EnemyState.Idle;

    public NavMeshAgent agent;

    public Transform player;
    public float detectRange = 10f;
    public float viewAngle = 90f;

    void Update()
    {
        Vector3 direction  = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(direction, transform.forward);

        // Perform a raycast to check if the player is within line of sight
        Ray ray = new Ray(transform.position, direction);
        RaycastHit[] hits = Physics.RaycastAll(ray, detectRange);
        
        if (hits.Length > 0)
        {
            // Sort the hits by distance to ensure we check the closest objects first
            Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform == player && angle < viewAngle / 2)
                {
                    currentState = EnemyState.Chasing;
                    
                    Debug.DrawRay(transform.position, direction * hits[i].distance, Color.green);
                    break;
                }
            }
        }

        if (currentState == EnemyState.Chasing)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
