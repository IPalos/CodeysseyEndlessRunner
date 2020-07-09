using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefloor : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    public float speed;
    // Start is called before the first frame update
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update () {
        if (GameBrain.gameStarted) {
            spriteRenderer.materials[0].mainTextureOffset = new Vector2 ((Time.time * speed), 0f);
        }

    }
}