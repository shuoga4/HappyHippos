using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDispenser : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * 被スクリプト：プレファブボール
     * 求められる挙動：
     * ディスペンサーの位置の取得
     * Instantiateで複製？
     * 
     * どっちのボールがどれぐらい出るのか
     * 左右での釣り合い
     * 
     * 処理
     * ５０％の確率でたま出現
     * 色も５０パーセンㇳ
     * 結構出したほうが面白い
     * 
     * 面白さ+
     * 勢いを作る？
     * ボールがたくさん出ることがある
     * 
     * これらすべてをプレファブボールで管理して良いのか
     * 考えられるのは、勢いとか確率を別スクリプトで管理する？
     * どっかからboolでtrueでボールを出現させる
     * 
     * trueどっちに置く？
     * プレファブの弱点はfrom ワールド to prefab の読み込みはできるけど逆はできないこと
     * prefabに世界は見えない
     * 無理だったらその度学べばいいか
     * 
     * 
     * 進展、そもそもプレファブは現実に拡張機能を与えるだけ、ヒエラルキーにアタッチは当然できるけど、そもそも型みたいなものなんだからヒエラルキーが型に影響を与えるっておかしい。
     * 
     * 
     */


    /*
     * 被スクリプト：ディスペンサー
     * 求められる挙動：
     * ボールのプレファブの取得
     * instantiateで複製
     * 
     */

    /*
     * カウンターが無いなら作ればいいじゃない
     */
    public GameObject redBall;
    public GameObject blueBall;
    public Canvas button;
    [System.NonSerialized] public bool start;
    [System.NonSerialized] public int fixedupdater;
    void Start() 
    {
        Boolfalser();
        fixedupdater = 0;
    }

    public void Boolfalser()
    {
        start = false;
    }

    public void Starter()
    {
        button.gameObject.SetActive(false);
        start = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fixedupdater++;
        if(fixedupdater % 100 == 0)
        {
            if (start)
                Instantiater();
        }


    }

    void Instantiater()
    {
        var roll = Random.Range(0, 2);
        switch (roll)
        {
            case 0:
                Instantiate(redBall, transform.position, Quaternion.identity, transform);
                break;
            case 1:
                Instantiate(blueBall, transform.position, Quaternion.identity, transform);
                break;
            default:
                Debug.Log("default");
                break;

        }
    }
}
