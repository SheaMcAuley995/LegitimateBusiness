using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {

	public MoneyManager Instance { get; private set; }

    public float startingMoney;

    public float Money { get; private set; }



    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(float amt)
    {
        Money += amt;
    }

    public void SubtractMoney(float amt)
    {
        Money -= amt;
    }

}
