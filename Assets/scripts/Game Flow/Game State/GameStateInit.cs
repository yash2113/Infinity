using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateInit : GameState
{
    public GameObject menuUI;
    [SerializeField]
    private TextMeshProUGUI hiscoreText;
    [SerializeField]
    private TextMeshProUGUI fishcountText;

    public override void Construct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Init);

        hiscoreText.text = "HighScore : " + SaveManager.Instance.save.HighScore.ToString();
        fishcountText.text = "Fish : " + SaveManager.Instance.save.Fish.ToString();

        menuUI.SetActive(true);
    }

    public override void Destruct()
    {
        menuUI.SetActive(false);
    }


    public void OnPlayClick()
    {
        brain.ChangeState(GetComponent<GameStateGame>());
        GameStats.Instance.ResetSession();
        GetComponent<GameStateDeath>().EnableRevive();
    }

    public void OnShopClick()
    {
        brain.ChangeState(GetComponent<GameStateShop>());
    }



}
