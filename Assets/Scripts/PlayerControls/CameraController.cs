using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float sensitivity;



    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivity);
        }
    }

}
