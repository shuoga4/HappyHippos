using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * 被スクリプト：壁
     * 求められる挙動
     * ボールにランダム性を、反射をもっとするべき
     * 択１：トリガー反射
     * 択２：コリジョン検出してぶつかったらなんかランダム性の高いことする
     * 
     * 
     */

    //ボールにもコリジョン検出でボール間のぶつかりを面白くできるのでは

    /*
     * 択２について
     * ランダム性をどう生むか
     * Eulerで0~180ランダムの値入れて飛ばすか？
     * ボールがぶつかるものはボールか壁の二択なんだからどっちも速度維持させれば減速することはない
     * けどトリガーのほうが実は確実性は高いけど、どうせ変わりそうだしランダム性ってことで速度もランダムにすればいいんじゃないか
     * そこで相対倍数じゃなくて加速を定数で行う足し算方式か、絶対値を与える方式かでいけばいい
     * 
     * ぶっちゃけコーディングするよりこっちでどんな挙動にするか考察シてる方が楽しいいいぃ
     * でもここでめっちゃ文字書くおかげで対して生産性高くない時間でもその通りに実装しようって気になるから
     * やっぱ大切なことではある
     * 
     * どうやってぶっ飛ばすの？
     * そうかRigidBody持ちだから普通に取得して、AddForceしていいのか？あるいはVelocity か？
     * 
     * 力を加えたいわけじゃなくてVelocity 情報補足してマグニチュードで長さとってランダム化した単位ベクトルにかければいいんだ
     * やっと組み立てできたかな
     * 
     * 新問題
     * 単位ベクトルのランダム化ってどっち向いてるかわからんのにできるもんなんか
     * 当たった場所の法線ベクトルがあればそこから-90~90まで読める
     * これ前みたいにどっちの壁ぶつかってもおかしな方向にならんか？
     * それはそれでええのかもしれん
     * 
     * 一旦ぐちゃってもいいから実装してみて経過みる
     * いや、一生壁にぶつかり続けるボールの未来を予知した
     * 
     * 一応座標で管理するか
     * 壁は上下左右それぞれで共通のオブジェクトになってる
     * 全然美しくない
     * やっぱ当たった場所の法線ベクトルを入手する手段を調べるか
     * 
     * ボールの位置の方向に伸ばしたベクトルは法線っぽい
     * 柵のtransforｍがぶっ壊れ位置にあるから機能しなそう
     * あ、360度にすればいいんじゃね
     * 
     * ランダムを360度にしたら半分は壁にぶつかるけど無限にぶつかることはなくなる
     * 結構良さそう
     * 
     * 
     * 
     */

    public float addSpeed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Red"))
            Hitter(collision.gameObject);//do something...
        if (collision.gameObject.CompareTag("Blue"))
            Hitter(collision.gameObject);//do something...
    }
    void Hitter(GameObject ball)
    {
        var random = Random.Range(0, 361);
        var rb = ball.GetComponent<Rigidbody>();
        var mag = rb.velocity.magnitude;
        mag = mag + addSpeed;
        var onevector = Quaternion.Euler(0, random, 0) * Vector3.forward;
        rb.velocity = onevector * mag;
        

    }
}
