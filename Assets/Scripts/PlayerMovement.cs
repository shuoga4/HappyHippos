using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
     * 床にぶつかるともうy軸固定する？
     * redゾーンに入ってるのに...みたいなことなる
     * あ、見えない立方体置いてその空間内のときこの判定が起こるようにすればええんでねか
     * トリガーシステム採用
     * 
     * やったこと無いんだけど当たり判定無いボックス置くだけでいいんだっけ
     * 
     * listを使ってspace押すと消える挙動を作りたい
     */
    private int _redCounter;
    private int _blueCounter;
    [System.NonSerialized] public int scoreCounter;
    private List<GameObject> _ballInFloorList = new();
    public Material redchanger;
    public Material bluechanger;
    public Material redorigin;
    public Material blueorigin;
    public Score score;
    public TextMeshProUGUI _scorex;
    void Start()
    {
    }
    /*      triggerenter用
     *      if (collision.gameObject.CompareTag("Red"))
           redCounter++;
       if (collision.gameObject.CompareTag("Blue"))
           blueCounter++;


       ballInFloorList.Add(collision.gameObject);
       Changer(collision.gameObject); 
    */

    /*      triggerexit用
     *         if (collision.gameObject.CompareTag("Red"))
            redCounter--;
        if (collision.gameObject.CompareTag("Blue"))
            blueCounter--;


        ballInFloorList.Remove(collision.gameObject);
        Changer2(collision.gameObject);
     */

    private void OnTriggerEnter(Collider other)
    {
        var othergo = other.gameObject;
        if (othergo.CompareTag("Red"))
            _redCounter++;
        if (othergo.CompareTag("Blue"))
            _blueCounter++;


        _ballInFloorList.Add(othergo);
        Changer(othergo);
    }

    private void OnTriggerExit(Collider other)
    {
        var othergo = other.gameObject;
        if (othergo.CompareTag("Red"))
            _redCounter--;
        if (othergo.CompareTag("Blue"))
            _blueCounter--;


        _ballInFloorList.Remove(othergo);
        Changer2(othergo);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Getter();

        _scorex.text = "red:" + _redCounter + "   blue:" + _blueCounter + "   score:" + scoreCounter;

    }
    void Getter()
    {
        if (score.toggleSpacePush != true)
        {
            scoreCounter += _redCounter * 2;
            scoreCounter -= _blueCounter;
            _redCounter = 0;
            _blueCounter = 0;
        
            foreach (GameObject go in _ballInFloorList)
            {
                if (go != null)
                    Destroy(go);
                continue;
            }
        }
       
    }
    //  リストを学ぶために色を変える
    void Changer(GameObject obj)
    {
        var objmesh = obj.GetComponent<MeshRenderer>();
        //リストの長さ読み出して？foreach使えないんだっけ？中身のゲームオブジェクト一つ一つにアタッチできる文募
        if(obj.CompareTag("Red"))
            objmesh.material = redchanger;
        if (obj.CompareTag("Blue"))
            objmesh.material = bluechanger;

    }

    void Changer2(GameObject obj)
    {
        var objmesh = obj.GetComponent<MeshRenderer>();
        if (obj.CompareTag("Red"))
            objmesh.material = redorigin;
        if (obj.CompareTag("Blue"))
            objmesh.material = blueorigin;
    }
    //多分色ごっちゃになるけどええか
    /* 予想通りなったので一旦変えてみる
     * 色濃くなる演出どうかな
     * 
     *
     * 
     */
}
