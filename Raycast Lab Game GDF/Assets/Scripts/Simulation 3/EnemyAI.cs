using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
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
        
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(directionToPlayer, transform.forward);

        // Perform a raycast to check if the player is within line of sight
        if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, detectRange))
        {
            if (hit.transform == player && angle < viewAngle / 2)
            {
                currentState = EnemyState.Chasing;
                
                // Draw a ray in the Scene view for visualization
                Debug.DrawRay(transform.position, directionToPlayer * hit.distance, Color.green);
            }
            else
            {
                currentState = EnemyState.Idle;
            }
        }
        else
        {
            currentState = EnemyState.Idle;
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
