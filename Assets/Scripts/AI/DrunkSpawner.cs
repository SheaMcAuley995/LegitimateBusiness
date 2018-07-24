using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkSpawner : MonoBehaviour {

    public GameObject drunkGuy;
    public GameObject drunkMesh;
    public Transform spawnPoint;
    public GameObject pizza;
    public RoundManager roundManager;

    public float waveSize = 0f;
    public float countDown = 2f;

    public List<GameObject> drunks;
    public List<GameObject> drunkMeshs;
   

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
            Destroy(drunkMeshs[i].gameObject);
        }
        drunks.Clear();
        drunkMeshs.Clear();
    }


    IEnumerator spawnDrunk()
    {
        for(int i = 0; i<waveSize;i++)
        {
            GameObject drunkmesh = Instantiate(drunkMesh, spawnPoint.position, spawnPoint.rotation);
            GameObject drunk = Instantiate(drunkGuy, spawnPoint.position, spawnPoint.rotation);
            drunk.GetComponent<DrunkAi>().target = pizza;
            drunks.Add(drunk);
            drunkMeshs.Add(drunkmesh);
            drunkmesh.GetComponent<DrunkMeshFollow>().DrunkBallRB = drunk.GetComponent<Rigidbody>();
            drunkmesh.GetComponent<DrunkMeshFollow>().BallPos = drunk.GetComponent<Transform>();
            yield return new WaitForSeconds(countDown);

        }
    }
}
