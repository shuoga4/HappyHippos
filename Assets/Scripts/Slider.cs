using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * 問題点
     * 明らかにバウンスに面白みがない
     * スライダーを動かしても端に貯まるのは確定では
     * ボールの速度を維持したい
     * 
     * 床に細工するのが一番良さそう
     * ランダム性の追加
     * どのみち端に貯まるのは変わらないか
     * もしかして壁になにか挙動をつければいいのでは
     * コリジョン反射じゃなくてトリガーで反射係数読むあれ
     * 
     * 
     */
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
