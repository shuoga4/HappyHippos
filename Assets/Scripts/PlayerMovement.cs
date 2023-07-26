using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * 被スクリプト：赤床
     * 求められる挙動
     * スペースを押すと床の上にあるボールが消える
     * 自分の色だと+2点、敵の色だと-1点の処理
     * 
     * なんか挙動おかしそうだけどやってみる
     * 入ったものを検知するため、一斉に消すためにやっぱり配列使う必要ありそう
     * 
     */
    [System.NonSerialized] public int redCounter;
    [System.NonSerialized] public int blueCounter;
    [System.NonSerialized] public int scoreCounter;
    public List<GameObject> ballInFloorList = new();
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red"))
            redCounter++;
        if (collision.gameObject.CompareTag("blue"))
            blueCounter++;
        ballInFloorList.Add(collision.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red"))
            redCounter--;
        if (collision.gameObject.CompareTag("Blue"))
            blueCounter--;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Getter();
        

    }
    void Getter()
    {
        scoreCounter = redCounter * 2;
        scoreCounter -= blueCounter;
        redCounter = 0;
        blueCounter = 0;
    }
    //  リストを学ぶために色を変える
    void Changer()
    {
        //リストの長さ読み出して？foreach使えないんだっけ？中身のゲームオブジェクト一つ一つにアタッチできる文募

    }
}
