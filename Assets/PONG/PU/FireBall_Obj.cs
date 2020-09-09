using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (CircleCollider2D))]
public class FireBall_Obj : MonoBehaviour {
    public Rigidbody2D rig;
    Vector2 dir;
    // Start is called before the first frame update
    void Start () {
        Destroy (this.gameObject, 20);
        rig = GetComponent<Rigidbody2D> ();
    }

    private void Update () {
        transform.Translate (dir * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.name == "Player1") {
            GameObject.Find ("Player2").GetComponent<PlayerControl> ().IncrementScore ();
            FindObjectOfType<BallControl> ().SendMessage ("RestartGame");
            Destroy (this.gameObject);
        } else if (other.name == "Player2") {
            GameObject.Find ("Player1").GetComponent<PlayerControl> ().IncrementScore ();
            FindObjectOfType<BallControl> ().SendMessage ("RestartGame");
            Destroy (this.gameObject);
        }
    }
    public void Launch (Vector2 dir) {
        this.dir = dir;
        if (dir.x < 0) {
            this.transform.localScale = new Vector3 (-1, 1, 1);
        }
    }
}