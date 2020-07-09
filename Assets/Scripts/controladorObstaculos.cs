using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class controladorObstaculos : MonoBehaviour {
    public GameObject[] obstaculos;
    public Transform[] posiciones;

    [SerializeField] float obstacleSpeed;
    [SerializeField] float waitInterval;

    private void Update() {
        if (Input.GetButtonDown("Jump") && !GameBrain.gameStarted){
            GameBrain.gameStarted = true;
            GameBrain.gameOver= false;
            StartCoroutine(StartGame());
        }

    }

    public IEnumerator StartGame () {
        while (GameBrain.gameStarted && !GameBrain.gameOver) {
            int chosenObstacle = Random.Range(0,obstaculos.Length);
            Transform chosenTransform = null;
            if(chosenObstacle == 4){
                chosenTransform = posiciones[1];
            }
            else{
                chosenTransform = posiciones[0];
            }
            GameObject obstaculo = Instantiate (obstaculos[chosenObstacle], chosenTransform.position , Quaternion.identity,transform);
            obstaculo.GetComponent<Rigidbody2D> ().velocity = new Vector2(-obstacleSpeed,0);
            yield return new WaitForSeconds (Random.Range(waitInterval-1,waitInterval+1));

        }
    }

}