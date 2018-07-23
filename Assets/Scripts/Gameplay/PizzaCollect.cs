using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCollect : MonoBehaviour {

    public static PizzaCollect Instance;

    public delegate void OnCollectChange();
    public PizzaCollect onCollectChange;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Drunk")
        {
            Destroy(this.gameObject);
        }
    }
}
