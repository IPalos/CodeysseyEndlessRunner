using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBrain : MonoBehaviour {

    public static bool gameStarted;
    public static bool gameOver;

    public static int score;
    public static int hiscore;
    float time = 0;

    private void Start () {
        score = 0;
        gameOver = false;
        gameStarted = false;
    }

    private void FixedUpdate () {
        hiscore=Mathf.Max(score,hiscore);
        Mathf.Repeat(time,.1f);
        if(gameStarted && time <.005f){
            score+=1;
        }
        if(gameOver){
            score=0;
        }
        if(score%100==0){
        }

    }

}