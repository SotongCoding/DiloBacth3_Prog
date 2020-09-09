using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl_Mag : MonoBehaviour {
    public GameObject pausePanel;
    public Text levelClearTxt;
    public GameObject controlMenu;

    private Scene currActiveScene;
    // Start is called before the first frame update
    void Start () {
        currActiveScene = SceneManager.GetActiveScene ();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            pauseGame ();
            levelClearTxt.text = "PAUSE";
        }
    }
    public void SetDialogText (string text) {
        levelClearTxt.text = text;
    }

    public void pauseGame () {
        Time.timeScale = 0;
        pausePanel.SetActive (true);
    }

    public void resumeGame () {
        Time.timeScale = 1;
        pausePanel.SetActive (false);
    }

    public void restartGame () {
        Time.timeScale = 1;
        SceneManager.LoadScene (currActiveScene.name);
    }

    public void endGame () {
        Time.timeScale = 0;
        pausePanel.SetActive (true);

        pausePanel.transform.Find ("Resume").gameObject.SetActive (false);

    }
}