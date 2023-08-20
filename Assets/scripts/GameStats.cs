using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance { get { return instance; } }
    private static GameStats instance;

    //Score
    public float score;
    public float highscore;
    public float distanceModifier = 1.5f;

    //Fish
    public int totalFish;
    public int fishCollectedThisSession;
    public float pointsPerFish = 10.0f;

    //Internal Cooldown
    private float lastScoreUpdate;
    private float scoreUpdateDelta = 0.2f;


    //Action
    public Action<int> OnCollectFish;
    public Action<float> OnScoreChange;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        float s = GameManager.Instance.motor.transform.position.z * distanceModifier;
        s += fishCollectedThisSession * pointsPerFish;
        if (s > score)
        {
            score = s;
            if (Time.time - lastScoreUpdate > scoreUpdateDelta)
            {
                lastScoreUpdate = Time.time;
                OnScoreChange?.Invoke(score);

            }
        }
    }


    public void CollectFish()
    {
        fishCollectedThisSession++;
        OnCollectFish?.Invoke(fishCollectedThisSession);
    }

    public void ResetSession()
    {
        score = 0;
        fishCollectedThisSession = 0;

        OnCollectFish?.Invoke(fishCollectedThisSession);
        OnScoreChange?.Invoke(score);
    }


    public string ScoreToText()
    {
        return score.ToString("0000000");
    }

    public string FishToText()
    {
        return fishCollectedThisSession.ToString("0000");
    }

}
