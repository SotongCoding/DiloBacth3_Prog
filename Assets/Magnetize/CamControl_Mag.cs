using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl_Mag : MonoBehaviour {
    Transform player;
    // Start is called before the first frame update
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update () {
        this.transform.position = new Vector3 (
            player.position.x,
            player.position.y, -10
        );
    }
}