using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManagement : MonoBehaviour {
    PipeSpawner pipe;
    Bird bird;
    public GameObject ready;

    private void Start () {
        pipe = FindObjectOfType<PipeSpawner> ();
        bird = FindObjectOfType<Bird> ();

        pipe.enabled = false;
        bird.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
    }
    public void StartGame (float time) {
        StartCoroutine (IeStartGame (time));
    }
    // Start is called before the first frame update
    IEnumerator IeStartGame (float time) {
        yield return new WaitForSeconds (time);

        pipe.enabled = true;
        bird.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
        ready.SetActive (false);
        this.gameObject.SetActive (false);
        bird.DoShoot ();

    }

    public void RestartGame () {
        SceneManager.LoadScene ("Flapy");
    }
}