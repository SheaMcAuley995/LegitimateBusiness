using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkMeshFollow : MonoBehaviour {

    public float rotateSpeed;
    public float yOffset;

    public Rigidbody DrunkBallRB;
    public Transform BallPos;

	void Update () {
        transform.position = BallPos.position + Vector3.up * yOffset;
        Vector3 walkDir = new Vector3(DrunkBallRB.velocity.x, 0, DrunkBallRB.velocity.z);
        Quaternion lookAtRotation = Quaternion.LookRotation(walkDir.normalized, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation,
                                              lookAtRotation,
                                              rotateSpeed * Time.deltaTime);
    }

}
