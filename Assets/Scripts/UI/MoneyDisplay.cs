using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    public Text moneyText;
    public Text pizzaCostText;

    public RoundManager roundManager;



    private void Start()
    {
        MoneyManager.Instance.onMoneyChange += OnMoneyChange;
        OnMoneyChange(MoneyManager.Instance.Money);

        pizzaCostText.text = "Cost of Pizza at Round End: $" + (int)roundManager.costOfPizza;
    }

    public void OnMoneyChange(float money)
    {
        moneyText.text = "$" + (int)money;
    }

}
