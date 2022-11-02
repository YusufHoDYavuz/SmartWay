using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PathMover : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator anim;

    Queue<Vector3> pathPoints = new Queue<Vector3>();

    public PathCreator PC;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        PC.OnNewPathCreated += SetPoints;
    }

    void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }

    void Update()
    {
        UpdatePathing();
    }

    void UpdatePathing()
    {
        if (ShouldSetDestination())
        {
            navMeshAgent.SetDestination(pathPoints.Dequeue());
            anim.SetBool("isRun", true);
        }
       
    }

    bool ShouldSetDestination()
    {
        if (pathPoints.Count == 0)
            return false;

        if (navMeshAgent.hasPath == false || navMeshAgent.remainingDistance < 0.5f)
            return true;

        return false;
    }
}
