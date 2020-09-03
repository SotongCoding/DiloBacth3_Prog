using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // Start is called before the first frame update
    [SerializeField] float speed;
    private void OnCollisionEnter2D (Collision2D other) {

        if (other.gameObject.tag == "pipe") {
            other.gameObject.GetComponent<Pipe> ().ReduceHealth ();
            Destroy(this.gameObject);
        }
    }

    private void Update () {
        transform.Translate (Vector2.right * Time.fixedDeltaTime * speed);
    }
}