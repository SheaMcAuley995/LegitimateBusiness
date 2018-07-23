using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    public Text moneyText;



    private void Start()
    {
        MoneyManager.Instance.onMoneyChange += OnMoneyChange;
        OnMoneyChange(MoneyManager.Instance.Money);
    }

    public void OnMoneyChange(float money)
    {
        moneyText.text = "$" + (int)money;
    }

}
