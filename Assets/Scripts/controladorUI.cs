using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorUI : MonoBehaviour {

public Text t_score;
public Text t_hiscore;

public GameObject GO_gameOver;


private void OnGUI() {
    t_score.text = "Score = "+ GameBrain.score.ToString();
    t_hiscore.text = "Hi-Score = "+ GameBrain.hiscore.ToString();
    if(GameBrain.gameOver){
        GO_gameOver.SetActive(true);
    }
    if(GameBrain.gameStarted){
        GO_gameOver.SetActive(false);
    }
}



}