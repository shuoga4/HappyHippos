using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    //簡単なWINの実装
    public EnemyMovement enemy;
    public PlayerMovement player;
    public Canvas winCanvas;
    public Canvas loseCanvas;
    [System.NonSerialized] public bool toggleSpacePush; // trueのとき操作不可
    public Canvas restartButton;

    void Start()
    {
        toggleSpacePush = false;
        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(toggleSpacePush == false)
        {
            if (player.scoreCounter >= 50)
            {
                winCanvas.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                toggleSpacePush = true;
            }

            if (enemy.scoreCounter >= 50)
            {
                loseCanvas.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                toggleSpacePush = true;
            }
        }
       
    }
    //restart button用メソッド
    public void Reseter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
