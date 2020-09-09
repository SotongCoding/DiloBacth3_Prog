using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (CircleCollider2D))]
[RequireComponent (typeof (AudioSource))]
public class PlayerControl_Mag : MonoBehaviour {
    private Rigidbody2D rb2D;
    public float moveSpeed = 5f;
    public AudioClip[] audios;

    //ON tower
    public float pullForce = 100f;
    public float rotateSpeed = 360f;
    private GameObject closestTower;
    private GameObject hookedTower;
    private bool isPulled = false;

    UIControl_Mag uiControl;

    //Sound
    private AudioSource myAudio;
    private bool isCrashed = false;
    // Start is called before the first frame update
    void Start () {
        rb2D = this.gameObject.GetComponent<Rigidbody2D> ();
        uiControl = FindObjectOfType<UIControl_Mag> ();
        myAudio = this.gameObject.GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update () {
        //Move the object
        rb2D.velocity = -transform.up * moveSpeed;

        if (hookedTower) {
            float distance = Vector2.Distance (transform.position, hookedTower.transform.position);
            //Gravitation toward tower
            Vector3 pullDirection = (hookedTower.transform.position - transform.position).normalized;
            float newPullForce = Mathf.Clamp (pullForce / distance, 20, 50);
            rb2D.AddForce (pullDirection * newPullForce);
            //Angular velocity
            rb2D.angularVelocity = -rotateSpeed / distance;

            // this.transform.RotateAround (hookedTower.transform.position, 
            // Vector3.forward, -rotateSpeed *Time.deltaTime);

            // isPulled = true;
        } else {

            isPulled = false;
            hookedTower = null;
            rb2D.angularVelocity = 0;
        }

    }

    public void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Wall") {
            //Ply Audio
            if (!isCrashed) {
                //Play SFX
                myAudio.PlayOneShot (audios[0]);
            }

            uiControl.endGame ();
            uiControl.SetDialogText ("KAU KALAH");
        }
    }
    public void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Finish") {
            uiControl.endGame ();
            uiControl.SetDialogText ("KAU MENANG");
        }
    }
    public void OnTriggerStay2D (Collider2D collision) {
        if (collision.gameObject.tag == "Tower") {
            closestTower = collision.gameObject;
            closestTower.GetComponent<TowerControl_Mag> ().hookAble = true;

            //Change tower color back to green as indicator
            collision.gameObject.GetComponent<SpriteRenderer> ().color = Color.magenta;
        }
    }
    public void OnTriggerExit2D (Collider2D collision) {
        if (isPulled) return;

        if (collision.gameObject.tag == "Tower") {
            closestTower.GetComponent<TowerControl_Mag> ().hookAble = false;
            closestTower = null;
            hookedTower = null;
            //Change tower color back to normal
            collision.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
        }
    }

    public void SetHookedTower (GameObject tower) {
        hookedTower = tower;
    }
}