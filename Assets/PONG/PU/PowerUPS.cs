using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPS : MonoBehaviour {
    protected GameObject target;
    // Start is called before the first frame update
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.name == "Ball") {
            if (other.GetComponent<Rigidbody2D> ().velocity.x > 0) {
                target = GameObject.Find ("Player1");
                PickUp ();
            } else {
                target = GameObject.Find ("Player2");
                PickUp ();
            }
            Destroy ();
        }
    }

    public virtual void PickUp () {

    }
    public virtual void Destroy () {
        Destroy (this.gameObject);
    }

    protected GameObject GetOppositeObj () {
        if (target.name == "Player1") return GameObject.Find ("Player2");
        else return GameObject.Find ("Player1");

    }

}