using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkMeshFollow : MonoBehaviour {

    public float rotateSpeed;

    public Rigidbody DrunkBallRB;
    public Transform BallPos;

	void Update () {
        transform.position = BallPos.position;
        Vector3 walkDir = new Vector3(DrunkBallRB.velocity.x, 0, DrunkBallRB.velocity.z);
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, walkDir.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              toRotation,
                                              rotateSpeed * Time.deltaTime);
    }

}
