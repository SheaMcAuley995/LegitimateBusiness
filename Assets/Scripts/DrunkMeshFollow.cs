using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkMeshFollow : MonoBehaviour {

    public Rigidbody DrunkBallRB;
    public Transform BallPos;

	void Update () {
        transform.position = BallPos.position;
       // transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        transform.rotation = Quaternion.LookRotation(DrunkBallRB.velocity, Vector3.up);
	}

}
