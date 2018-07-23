using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementTimeDisplay : MonoBehaviour {

    public RoundManager roundManager;
    public Text displayText;



    private void Awake()
    {
        roundManager.AddOnTimerStart(OnTimerStart);
        roundManager.AddOnTimerFinish(OnTimerFinish);
    }

    private void Update()
    {
        displayText.text = "Time remaining to place: " + (int)roundManager.placementTimer;
    }

    private void OnTimerStart()
    {
        displayText.gameObject.SetActive(true);
    }

    private void OnTimerFinish()
    {
        displayText.gameObject.SetActive(false);
    }

}
