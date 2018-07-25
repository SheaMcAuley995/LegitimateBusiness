using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

    public float moneyWhenBroken;
    public GameObject brokenPieces;
    public AudioSource ads;



    private void Awake()
    {
        brokenPieces.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Drunk")
        {
            BreakableManager.Instance.RemovePlacedObject(gameObject);

            brokenPieces.transform.parent = null;

            Transform[] pieces = brokenPieces.transform.GetComponentsInChildren<Transform>();
            foreach(Transform p in pieces)
            {
                p.eulerAngles = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            }

            brokenPieces.SetActive(true);
            BreakableManager.Instance.AddBrokenPieces(brokenPieces);

            MoneyManager.Instance.AddMoney(moneyWhenBroken);

            AudioManager.Instance.ads.pitch = ads.pitch;
            AudioManager.Instance.ads.PlayOneShot(ads.clip);

            Destroy(gameObject);
        }
    }

}
