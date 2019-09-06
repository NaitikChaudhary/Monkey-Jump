using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D myBody;

    public float move_speed = 2f;

    public float normal_Push = 10f;

    public float extra_Push = 14f;

    private bool initial_Push;

    private bool player_Died;

    private int push_Count;


    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {

        if(player_Died) {
            return;
        }

        if(Input.GetAxisRaw("Horizontal") > 0) {
            myBody.velocity = new Vector2(move_speed, myBody.velocity.y);
        } else if(Input.GetAxisRaw("Horizontal") < 0) {
            myBody.velocity = new Vector2(-move_speed, myBody.velocity.y);
        }
    }

    // Update is called once per frame
    void Update() {
        // print("Velocity is " + myBody.velocity);
    }

    void OnTriggerEnter2D(Collider2D target) {

        // print("Tag is : " + target.tag);

        if(player_Died) {
            return;
        }

        if(!initial_Push) {
            if(target.tag == "ExtraPush") {
                initial_Push = true;
                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                target.gameObject.SetActive(false);
                SoundManager.instance.JumpSoundFx();
                return;
            }
        }

        if(target.tag == "NormalPush") {
            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);
            target.gameObject.SetActive(false);
            SoundManager.instance.JumpSoundFx();
            push_Count++;
        }

        if(target.tag == "ExtraPush") {
            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);
            target.gameObject.SetActive(false);
                SoundManager.instance.JumpSoundFx();
            push_Count++;
        }

        if(push_Count == 2) {
            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        if(target.tag == "FallDown" || target.tag == "Bird") {
            player_Died = true;
            SoundManager.instance.GameOverSoundFx();
            GameManager.instance.RestartGame();
        }

    }
}
