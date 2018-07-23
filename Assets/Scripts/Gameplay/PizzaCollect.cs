using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCollect : MonoBehaviour {

    public static PizzaCollect Instance { get; private set; }

    public delegate void OnCollectChange();
    public OnCollectChange onCollectChange;



    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Drunk")
        {
            if(onCollectChange != null)
            {
                onCollectChange();
            }
            //Destroy(this.gameObject);
        }
    }
}
