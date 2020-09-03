using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour {
    // Global Variables
    //Change Some
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private UnityEvent OnJump, OnDead;
    private Rigidbody2D rigidBody2d;
    private Animator animator;
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;

    [Header ("Peluru")]
    public GameObject bullet;


    //init variable
    void Start () {
        //Mendapatkan komponent ketika game baru berjalan
        rigidBody2d = GetComponent<Rigidbody2D> ();
        //Mendapatkan komponen animator pada game object   
        animator = GetComponent<Animator> ();
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        //menghentikan Animasi Burung ketika bersentukan dengan object lain
        animator.enabled = false;
    }
    //Update setiap frame  
    void Update () {
        //Melakukan pengecekan jika belum mati dan klik kiri pada mouse
        if (!isDead && Input.GetMouseButtonDown (0)) {
            //Burung meloncat
            Jump ();
        }
    }

    public void AddScore (int value) {
        //Menambahkan Score value
        score += value;
        //Mengubah nilai text pada score text
        scoreText.text = score.ToString ();

        //Pengecekan Null Value
        if (OnAddPoint != null) {
            //Memanggil semua event pada OnAddPoint
            OnAddPoint.Invoke ();
        }
    }
    //Fungsi untuk mengecek sudah mati apa belum
    public bool IsDead () {
        return isDead;
    }

    //Membuat Burung Mati
    public void Dead () {
        //Pengecekan jika belum mati dan value OnDead tidak sama dengan Null
        if (!isDead && OnDead != null) {
            //Memanggil semua event pada OnDead
            OnDead.Invoke ();
        }

        //Mengeset variable Dead menjadi True
        isDead = true;

    }

    void Jump () {
        //Mengecek rigidbody null atau tidak
        if (rigidBody2d) {
            //menghentikan kecepatan burung ketika jatuh
            rigidBody2d.velocity = Vector2.zero;

            //Menambahkan gaya ke arah sumbu y agar burung meloncat
            rigidBody2d.AddForce (new Vector2 (0, upForce));
        }

        //Pengecekan Null variable
        if (OnJump != null) {
            //Menjalankan semua event OnJump event
            OnJump.Invoke ();
        }
    }

    public void DoShoot () {
          InvokeRepeating("Shoot",7,2);
    }
    void Shoot () {
        GameObject bullet = Instantiate (this.bullet, transform.position, Quaternion.identity);
    }
}