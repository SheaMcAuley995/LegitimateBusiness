using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkSpawner : MonoBehaviour {

    public GameObject drunkGuy;
    public Transform spawnPoint;
    public GameObject pizza;
    public RoundManager roundManager;

    public float waveSize = 0f;
    public float countDown = 2f;

    public List<GameObject> drunks;

    public void Start()
    {

        if(roundManager != null)
        {
            roundManager.AddOnTimerFinish(startWaves);
            roundManager.AddOnPizzaReached(clearDrunks);
        }
        else
        {
            startWaves();
        }

    }

    public void startWaves()
    {
        StartCoroutine(spawnDrunk());
    }

    public void clearDrunks()
    {
        for (int i = 0; i < waveSize; i++)
        {
            Destroy(drunks[i].gameObject);
        }
        drunks.Clear();
    }


    IEnumerator spawnDrunk()
    {
        for(int i = 0; i<waveSize;i++)
        {
            GameObject drunk = Instantiate(drunkGuy, spawnPoint.position, spawnPoint.rotation);
            drunk.GetComponent<DrunkAi>().target = pizza;
            drunks.Add(drunk);
            yield return new WaitForSeconds(countDown);

        }
    }
}
