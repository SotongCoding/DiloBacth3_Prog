using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : PowerUPS
{
    public GameObject birdObj;

    public override void PickUp(){
        GameObject fireBirb = Instantiate(birdObj, transform.position, Quaternion.identity);
        if(base.target.name == "Player1") fireBirb.GetComponent<FireBall_Obj>().Launch(Vector2.right);
        else fireBirb.GetComponent<FireBall_Obj>().Launch(Vector2.left);
    }
}
