﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int score;

    Text text;
    
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (score < 0)
            score = 0;

        text.text = "" + score;
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
}
