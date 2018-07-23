using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour {

    public GameObject gameOverText;
    public RoundManager roundManager;




    private void Awake()
    {
        gameOverText.SetActive(false);
        roundManager.AddOnGameEnd(OnGameEnd);
    }

    private void OnGameEnd()
    {
        gameOverText.SetActive(true);
    }

}
