using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * 被スクリプト：ブルーゾーン
     * 求められる挙動
     * より高得点を狙うようなAIの実装
     * 
     * 未来予測的なことで言えば各ボールのvelo取って、
     * 自分の中に入るボールの量を把握
     * 常に把握して実際に高いところでゲットする
     * 
     * もしくは常にプレート内のゲット時スコアを把握して、＋だったらすぐに押すとか
     * 多分これが最強
     * 人を超えた速度ですべてのボールを一個づつ摘むようになる
     * 
     * これにcdやdelayを入れたら弱くなるんじゃね
     * fixedupdateのほうが良さそう
     * 
     * まず最強の実装
     * 
     * cd実装
     * boolで真のときcd解消
     * 偽のときon cd
     * on cd 中はgetterしてもgetできない
     * 
     */
    private int _redCounter;
    private int _blueCounter;
    private int _predic;
    private int tick;
    [System.NonSerialized] private int delay = 1;
    [System.NonSerialized] private int cooldown = 0;
    private bool cd;

    public Material redchanger;
    public Material bluechanger;
    public Material redorigin;
    public Material blueorigin;

    [System.NonSerialized] public int scoreCounter;
    private List<GameObject> _ballInFloorList = new();
    public TextMeshProUGUI _scorex;
    void Start()
    {
        tick = 0;
        cd = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tick++;
        Calc();
        if (cd == false)
            _predic = 0;
        if(tick % delay == 0)
        {
            if (_predic > 0)
                Getter();

        }

        _scorex.text = "red:" + _redCounter + "   blue:" + _blueCounter + "   score:" + scoreCounter;
    }
    void Calc()
    {
        //solved:常に乗ってるもののみの計算値、これだと前の加算される
        _predic = _blueCounter * 2;
        _predic -= _redCounter;
    }
    void Getter()
    {
        scoreCounter += _blueCounter * 2;
        scoreCounter -= _redCounter;
        _redCounter = 0;
        _blueCounter = 0;

        foreach (GameObject go in _ballInFloorList)
        {
            if (go != null)
                Destroy(go);
            continue;
        }
        //ここでcd boolを偽にして、Startcoroutineして何秒後かにそのboolを真にするものの実装、cd boolはどこで使うか
        cd = false;
        StartCoroutine(CoolDownBool());
    }

    IEnumerator CoolDownBool()
    {
        yield return new WaitForSeconds(cooldown);
        cd = true;
    }
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
    void Changer(GameObject obj)
    {
        var objmesh = obj.GetComponent<MeshRenderer>();
        //リストの長さ読み出して？foreach使えないんだっけ？中身のゲームオブジェクト一つ一つにアタッチできる文募
        if (obj.CompareTag("Red"))
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
}
