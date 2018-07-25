using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacer : MonoBehaviour {

    public float gridSquareSize;
    public GameObject[] prefabs;
    public GameObject[] fragilePrefabs;
    public float[] prefabCosts;
    public LayerMask floorMask;
    public LayerMask placedObjectMask;
    public float costCanvasHeightBoost;
    public float minPlaceSoundPitch;
    public float maxPlaceSoundPitch;

    [Header("Links")]
    public Camera cam;
    public RoundManager roundManager;
    public GameObject objectCostCanvas;
    public Text objectCostText;
    public AudioSource ads;
    public AudioClip placementSond;

    private int selection = 0;
    private int fragileSelection;
    private GameObject ghost;



    private void Awake()
    {
        roundManager.AddOnTimerStart(StartPlacing);
        roundManager.AddOnTimerFinish(StopPlacing);
        roundManager.AddOnRoundWin(StartPlacing);
    }

    private void Start()
    {
        StartPlacing();
    }

    private void OnValidate()
    {
        if(prefabs != null)
        {
            if (prefabCosts == null)
            {
                prefabCosts = new float[prefabs.Length];
            }
            if (prefabCosts.Length != prefabs.Length)
            {
                float[] newCosts = new float[prefabs.Length];
                for (int i = 0; i < prefabCosts.Length && i < newCosts.Length; ++i)
                {
                    newCosts[i] = prefabCosts[i];
                }
                prefabCosts = newCosts;
            }
        }
    }

    private void Update()
    {
        if(ghost == null)
        {
            return;
        }

        //Position ghost
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        ghost.SetActive(false);
        objectCostCanvas.SetActive(false);
        if (Physics.Raycast(ray, out hit, float.MaxValue, floorMask))
        {
            BoxCollider bx = ghost.GetComponent<BoxCollider>();
            ghost.transform.position = hit.point;
            ghost.transform.position = new Vector3(Mathf.Round(hit.point.x / gridSquareSize),
                                                   hit.point.y + ((bx.size.y / 2.0f) * ghost.transform.localScale.y),
                                                   Mathf.Round(hit.point.z / gridSquareSize));
            if(!Physics.CheckBox(ghost.transform.position, bx.size / (2.0f + float.MinValue), ghost.transform.rotation, placedObjectMask))
            {
                ghost.SetActive(true);
                objectCostCanvas.SetActive(true);
                objectCostCanvas.transform.position = ghost.transform.position + Vector3.up * costCanvasHeightBoost;
                objectCostCanvas.transform.LookAt(cam.transform);
            }
        }

        if(ghost.activeInHierarchy)
        {
            //Scroll through prefabs
            if (Input.mouseScrollDelta.y > 0)
            {
                ++selection;
                if (selection >= prefabs.Length)
                {
                    selection = 0;
                }
                ReplaceGhost();
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                --selection;
                if (selection < 0)
                {
                    selection = prefabs.Length - 1;
                }
                ReplaceGhost();
            }

            //Rotate ghost
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ghost.transform.Rotate(Vector3.up * -90);
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                ghost.transform.Rotate(Vector3.up * 90);
            }

            //Create object
            if (Input.GetMouseButtonDown(0) && ghost.activeInHierarchy
                && MoneyManager.Instance.Money >= prefabCosts[selection])
            {
                GameObject newobj;
                if (selection != 0)
                {
                    newobj = Instantiate(prefabs[selection]);
                }
                else
                {
                    newobj = Instantiate(fragilePrefabs[fragileSelection]);
                }
                BreakableManager.Instance.AddPlacedObject(newobj);
                newobj.transform.position = ghost.transform.position;
                newobj.transform.rotation = ghost.transform.rotation;
                MoneyManager.Instance.SubtractMoney(prefabCosts[selection]);
                ads.pitch = Random.Range(minPlaceSoundPitch, maxPlaceSoundPitch);
                ads.PlayOneShot(placementSond);
                if(selection == 0)
                {
                    ReplaceGhost();
                }
            }
        }
    }

    public void StopPlacing()
    {
        if(ghost != null)
        {
            Destroy(ghost);
            ghost = null;
            objectCostCanvas.SetActive(false);
        }
    }

    public void StartPlacing()
    {
        ReplaceGhost();
    }

    private void ReplaceGhost()
    {
        if(ghost != null)
        {
            Destroy(ghost);
        }
        MakeGhost();
    }

    private void MakeGhost()
    {
        if(selection == 0)
        {
            fragileSelection = Random.Range(0, fragilePrefabs.Length);
            ghost = Instantiate(fragilePrefabs[fragileSelection]);
        }
        else
        {
            ghost = Instantiate(prefabs[selection]);
        }
        ghost.transform.eulerAngles = Vector3.up * (90.0f * Random.Range(0, 5));
        objectCostText.text = "$" + prefabCosts[selection];
        ghost.SetActive(false);
    }

}
