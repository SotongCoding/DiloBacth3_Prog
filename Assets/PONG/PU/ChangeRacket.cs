using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRacket : PowerUPS {
    public float duration;
    GameObject curObj;
    public override void PickUp () {
        base.target.transform.localScale = new Vector2 (0.5f, 5);
        curObj = base.target;

    }
    public override void Destroy () {
        Invoke ("EndEffect", duration);
        this.gameObject.SetActive (false);
    }
    void EndEffect () {
        curObj.transform.localScale = new Vector2 (0.5f, 3.5f);
        Destroy (this.gameObject);

    }
}