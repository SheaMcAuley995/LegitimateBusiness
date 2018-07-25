using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObjects : MonoBehaviour {

    public Transform resetPos;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlacableObjects"))
        {
            collision.transform.position = resetPos.position;
        }
    }

}
