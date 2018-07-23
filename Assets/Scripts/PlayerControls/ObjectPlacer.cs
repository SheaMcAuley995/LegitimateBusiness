using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour {

    public float gridSquareSize;
    public GameObject[] prefabs;
    public Camera cam;
    public LayerMask floorMask;

    private int selection = 0;
    private GameObject ghost;



    private void Start()
    {
        StartPlacing();
    }

    private void Update()
    {

        //Position ghost
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, float.MaxValue, floorMask))
        {
            ghost.SetActive(true);
            ghost.transform.position = hit.point;
            ghost.transform.position = new Vector3(Mathf.Round(hit.point.x / gridSquareSize),
                                                   hit.point.y,
                                                   Mathf.Round(hit.point.z / gridSquareSize));
        }
        else
        {
            ghost.SetActive(false);
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
            if (Input.GetMouseButtonDown(0) && ghost.activeInHierarchy)
            {
                GameObject newobj = Instantiate(prefabs[selection]);
                newobj.transform.position = ghost.transform.position;
            }
        }
    }

    public void StopPlacing()
    {
        if(ghost != null)
        {
            Destroy(ghost);
            ghost = null;
        }
    }

    public void StartPlacing()
    {
        MakeGhost();
    }

    private void ReplaceGhost()
    {
        Destroy(ghost);
        MakeGhost();
    }

    private void MakeGhost()
    {
        ghost = Instantiate(prefabs[selection]);
        ghost.SetActive(false);
    }

}
