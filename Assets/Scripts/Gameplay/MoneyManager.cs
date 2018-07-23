using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {

	public static MoneyManager Instance { get; private set; }

    public float startingMoney;

    public float Money { get; private set; }

    public delegate void OnMoneyChange(float money);
    public OnMoneyChange onMoneyChange;



    private void Awake()
    {
        Instance = this;
        Money = startingMoney;
    }

    public void AddMoney(float amt)
    {
        Money += amt;
        if(onMoneyChange != null)
        {
            onMoneyChange(Money);
        }
    }

    public void SubtractMoney(float amt)
    {
        Money -= amt;
        if (onMoneyChange != null)
        {
            onMoneyChange(Money);
        }
    }

}
