using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Guard : MonoBehaviour
{

    public enum GuardState
    {
        Patrol,
        Chase,
    }

    private GuardState state;

    [SerializeField] Transform wayPoints;
    NavMeshAgent agent;

    [Header("Vision")]
    [SerializeField] float maxDistance;
    [SerializeField] float maxAngle;
    [SerializeField] Transform playerTransform;


    void ChooseNewDestination()
    {

        int index = Random.Range(0, wayPoints.childCount);
        Transform dest = wayPoints.GetChild(index);
        agent.SetDestination(dest.position);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        state = GuardState.Patrol;
        ChooseNewDestination();

    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case GuardState.Patrol:
                if (agent.remainingDistance <= 0.5f)
                {
                    ChooseNewDestination();
                }
                if (CanWeSeeThePlayer())
                {
                    state = GuardState.Chase;
                }
                break;
            case GuardState.Chase:
                agent.SetDestination(playerTransform.position);
                if (!CanWeSeeThePlayer())
                {
                    state = GuardState.Patrol;
                }
                break;
        }


        // if (Vector3.Distance(agent.destination, transform.position) <= 0.5f) {
    }

    bool CanWeSeeThePlayer()
    {
        RaycastHit hit;
        Vector3 playerDirection = playerTransform.position - transform.position;
        if (Physics.Raycast(transform.position + Vector3.up * 0.3f, playerDirection, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (Vector3.Angle(transform.forward, playerDirection) <= maxAngle)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
