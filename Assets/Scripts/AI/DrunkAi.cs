using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DrunkAi : MonoBehaviour {

    
    private Rigidbody rb;
    private NavMeshPath path;

    private Vector3 desiredDir;
    private Vector3 swayDir;

    public GameObject target;
    [Range(0,10)]
    public float thoughtProcessSpeed;
    [Range(0, 5)]
    public float drunkeness;
    public float waitTime;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        path = new NavMeshPath();
        StartCoroutine(detectObjects());
        //StartCoroutine(drunkSwayTime());
    }

    private void Update()
    {
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }

        Debug.DrawLine(transform.position, desiredDir, Color.green);

        rb.AddForce(desiredDir * 5);
    }

    IEnumerator drunkSwayTime()
    {
        while (true)
        {
            swayDir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            //StartCoroutine(drunkSwayPower());
            yield return new WaitForSeconds(5 - drunkeness);
        }
    }

    IEnumerator drunkSwayPower()
    {
        while (true)
        {
            rb.AddForce(swayDir, ForceMode.Force);
            Debug.DrawLine(transform.position, (transform.position - swayDir), Color.yellow);
            yield return null;
        }

    }

    IEnumerator detectObjects()
    {
        while (true)
        {
            NavMeshHit navMeshHitA;
            NavMeshHit navMeshHitB;
            NavMesh.SamplePosition(transform.position, out navMeshHitA, float.PositiveInfinity, NavMesh.AllAreas);
            NavMesh.SamplePosition(target.transform.position, out navMeshHitB, float.PositiveInfinity, NavMesh.AllAreas);
            bool result = NavMesh.CalculatePath(navMeshHitA.position, navMeshHitB.position, NavMesh.AllAreas, path);

            desiredDir = (path.corners[1] - transform.position).normalized;
            
           // print("Detection Activated");

            yield return new WaitForSeconds(waitTime);
        }

    }
}
