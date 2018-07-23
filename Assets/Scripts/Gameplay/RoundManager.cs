using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public delegate void OnStageChange();
    private OnStageChange onTimerStart;
    private OnStageChange onTimerFinish;
    private OnStageChange onPizzaReached;
    private OnStageChange onGameEnd;
    private OnStageChange onRoundWin;

    public float placementTime;
    public float costOfPizza;

    public float placementTimer { get; private set; }



    private void Awake()
    {
        AddOnPizzaReached(FinishRound);
    }

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

    private void FinishRound()
    {
        MoneyManager.Instance.SubtractMoney(costOfPizza);
        if(MoneyManager.Instance.Money <= 0 && onGameEnd != null)
        {
            onGameEnd();
        }
        else if(MoneyManager.Instance.Money > 0 && onRoundWin != null)
        {
            onRoundWin();
            StartRound();
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

    public void AddOnGameEnd(OnStageChange func)
    {
        if (onGameEnd == null)
        {
            onGameEnd = func;
        }
        else
        {
            onGameEnd += func;
        }
    }

    public void AddOnRoundWin(OnStageChange func)
    {
        if (onRoundWin == null)
        {
            onRoundWin = func;
        }
        else
        {
            onRoundWin += func;
        }
    }

}
