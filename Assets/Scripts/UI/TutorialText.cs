using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

    public GameObject tutorialText;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            tutorialText.SetActive(!tutorialText.activeInHierarchy);
        }
    }

}
