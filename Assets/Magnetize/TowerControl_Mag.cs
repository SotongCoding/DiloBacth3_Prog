using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl_Mag : MonoBehaviour {
    // Start is called before the first frame update
    PlayerControl_Mag playerControl;
    public bool hookAble;

    private void Start () {
        playerControl = FindObjectOfType<PlayerControl_Mag> ();
    }

    private void OnMouseDown () {
        if (hookAble)
            playerControl.SetHookedTower (this.gameObject);
    }
    private void OnMouseUp () {
        playerControl.SetHookedTower (null);
    }
}