using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableManager : MonoBehaviour {

	public static BreakableManager Instance { get; private set; }

    public RoundManager roundManager;

    private List<GameObject> brokenPieces = new List<GameObject>();
    private List<GameObject> placedObjects = new List<GameObject>();



    private void Awake()
    {
        Instance = this;
        roundManager.AddOnPizzaReached(Cleanup);
    }

    private void Cleanup()
    {
        foreach(GameObject g in brokenPieces)
        {
            Destroy(g);
        }
        //foreach(GameObject g in placedObjects)
        //{
        //    Destroy(g);
        //}
        brokenPieces.Clear();
        //placedObjects.Clear();
    }

    public void AddPlacedObject(GameObject obj)
    {
        placedObjects.Add(obj);
    }

    public void RemovePlacedObject(GameObject obj)
    {
        placedObjects.Remove(obj);
    }

    public void AddBrokenPieces(GameObject obj)
    {
        brokenPieces.Add(obj);
    }

}
