using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour {
    // Pemain yang akan bertambah skornya jika bola menyentuh dinding ini.
    public PlayerControl player;
    GameManager_pong gameManager;

    private void Start () {
        gameManager = FindObjectOfType<GameManager_pong> ();
    }
    // Akan dipanggil ketika objek lain ber-collider (bola) bersentuhan dengan dinding.
    void OnTriggerEnter2D (Collider2D anotherCollider) {

        // Jika objek tersebut bernama "Ball":
        if (anotherCollider.name == "Ball") {
            // Tambahkan skor ke pemain
            player.IncrementScore ();
            // Jika skor pemain belum mencapai skor maksimal...
            if (player.Score < gameManager.maxScore) {
                // ...restart game setelah bola mengenai dinding.
                anotherCollider.gameObject.SendMessage ("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
    // Update is called once per frame
    void Update () {

    }
}