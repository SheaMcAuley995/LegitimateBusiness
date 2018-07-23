using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DrunkAi : MonoBehaviour {

    private NavMeshPath path;
    public GameObject target;

    private void Start()
    {
        path = new NavMeshPath();
        StartCoroutine(detectObjects());
    }

    IEnumerator detectObjects()
    {
        NavMeshHit navMeshHitA;
        NavMeshHit navMeshHitB;
        NavMesh.SamplePosition(transform.position, out navMeshHitA, float.PositiveInfinity, NavMesh.AllAreas);
        NavMesh.SamplePosition(target.transform.position, out navMeshHitB, float.PositiveInfinity, NavMesh.AllAreas);
        bool result = NavMesh.CalculatePath(navMeshHitA.position, navMeshHitB.position, NavMesh.AllAreas, path);
        Debug.Log("Active: detectObjects");

        //Debug.Assert(result, "pls");
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
        yield return new WaitForSeconds(1);
    }
}
