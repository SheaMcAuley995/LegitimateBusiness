using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public delegate void OnStageChange();
    private OnStageChange onTimerStart;
    private OnStageChange onTimerFinish;
    private OnStageChange onPizzaReached;

    public float placementTime;

    public float placementTimer { get; private set; }



    private void Start()
    {
        StartRound();
    }

    private void Update()
    {
        if(placementTimer > 0)
        {
            placementTimer -= Time.deltaTime;
            if(placementTimer <= 0 && onTimerFinish != null)
            {
                onTimerFinish();
            }
        }
    }

    private void StartRound()
    {
        placementTimer = placementTime;
        if(onTimerStart != null)
        {
            onTimerStart();
        }
    }

    public void AddOnTimerStart(OnStageChange func)
    {
        if(onTimerStart == null)
        {
            onTimerStart = func;
        }
        else
        {
            onTimerStart += func;
        }
    }

    public void AddOnTimerFinish(OnStageChange func)
    {
        if (onTimerFinish == null)
        {
            onTimerFinish = func;
        }
        else
        {
            onTimerFinish += func;
        }
    }

    public void AddOnPizzaReached(OnStageChange func)
    {
        if (onPizzaReached == null)
        {
            onPizzaReached = func;
        }
        else
        {
            onPizzaReached += func;
        }
    }

}
