using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PURange : MonoBehaviour {
    public GameObject[] powerUPs;
    Vector2 Maxzone;
    // Start is called before the first frame update
    void Start () { InvokeRepeating ("SpawnRandom", 5, 10); }

    // Update is called once per frame
    void Update () {

    }

    public void SpawnRandom () {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane+5)); //will get the middle of the screen

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (
            Random.Range (0, Screen.width) - 10f,
            Random.Range (0, Screen.height) - 10f,
            Camera.main.farClipPlane / 2));
        GameObject pu = Instantiate (powerUPs[Random.Range (0, powerUPs.Length)],
            screenPosition, Quaternion.identity);

    }
}