using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class controlJugador : MonoBehaviour {

    public Rigidbody2D rb;
    bool jump = false;
    bool crouch = false;

    bool grounded = false;
    public float jumpForce = 400f;

    Animator animator;

    BoxCollider2D box;

    private void Start() {
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update () {

        if(GameBrain.gameStarted){
            animator.SetBool("GameStarted",true);
            animator.SetBool("GameOver",false);
        }

        if (Input.GetButtonDown ("Jump")) {
            jump = true;
        }

        if (Input.GetButtonDown ("Crouch") ) {
            crouch = true;
            animator.SetBool("Crouch",true);
        } else if (Input.GetButtonUp ("Crouch")) {
            crouch = false;
            animator.SetBool("Crouch",false);

        }

        if(crouch){
            box.size= new Vector2(0.575f,0.3f);
        }
        else{
            box.size = new Vector2(0.44f, 0.47f);
        }

    }

    void FixedUpdate () {
        // rb.ad
        // Move our character
        if (jump && grounded){
            FindObjectOfType<AudioManager>().Play("Scoring");
            rb.AddForce(new Vector2(0,jumpForce));

        }
            jump = false;
    }

    private void OnCollisionStay2D (Collision2D other) {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        grounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("obstaculo")){
            GameBrain.gameOver=true;
            animator.SetBool("GameOver",true);
            GameBrain.gameStarted = false;
        }
    }
}