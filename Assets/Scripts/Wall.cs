using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * ��X�N���v�g�F��
     * ���߂��鋓��
     * �{�[���Ƀ����_�������A���˂������Ƃ���ׂ�
     * ���P�F�g���K�[����
     * ���Q�F�R���W�������o���ĂԂ�������Ȃ񂩃����_�����̍������Ƃ���
     * 
     * 
     */

    //�{�[���ɂ��R���W�������o�Ń{�[���Ԃ̂Ԃ����ʔ����ł���̂ł�

    /*
     * ���Q�ɂ���
     * �����_�������ǂ����ނ�
     * Euler��0~180�����_���̒l����Ĕ�΂����H
     * �{�[�����Ԃ�����̂̓{�[�����ǂ̓���Ȃ񂾂���ǂ��������x�ێ�������Ό������邱�Ƃ͂Ȃ�
     * ���ǃg���K�[�̂ق������͊m�����͍������ǁA�ǂ����ς�肻�����������_�������Ă��Ƃő��x�������_���ɂ���΂����񂶂�Ȃ���
     * �����ő��Δ{������Ȃ��ĉ�����萔�ōs�������Z�������A��Βl��^����������ł����΂���
     * 
     * �Ԃ����Ⴏ�R�[�f�B���O�����肱�����łǂ�ȋ����ɂ��邩�l�@�V�Ă�����y����������
     * �ł������ł߂����ᕶ�������������ő΂��Đ��Y�������Ȃ����Ԃł����̒ʂ�Ɏ������悤���ċC�ɂȂ邩��
     * ����ϑ�؂Ȃ��Ƃł͂���
     * 
     * �ǂ�����ĂԂ���΂��́H
     * ������RigidBody���������畁�ʂɎ擾���āAAddForce���Ă����̂��H���邢��Velocity ���H
     * 
     * �͂����������킯����Ȃ���Velocity ���⑫���ă}�O�j�`���[�h�Œ����Ƃ��ă����_���������P�ʃx�N�g���ɂ�����΂�����
     * ����Ƒg�ݗ��Ăł�������
     * 
     * �V���
     * �P�ʃx�N�g���̃����_�������Ăǂ��������Ă邩�킩���̂ɂł������Ȃ�
     * ���������ꏊ�̖@���x�N�g��������΂�������-90~90�܂œǂ߂�
     * ����O�݂����ɂǂ����̕ǂԂ����Ă��������ȕ����ɂȂ�񂩁H
     * ����͂���ł����̂��������
     * 
     * ��U��������Ă���������������Ă݂Čo�߂݂�
     * ����A�ꐶ�ǂɂԂ��葱����{�[���̖�����\�m����
     * 
     * �ꉞ���W�ŊǗ����邩
     * �ǂ͏㉺���E���ꂼ��ŋ��ʂ̃I�u�W�F�N�g�ɂȂ��Ă�
     * �S�R�������Ȃ�
     * ����ϓ��������ꏊ�̖@���x�N�g������肷���i�𒲂ׂ邩
     * ���肢�����U�X�g�b�v�ŁA�{�ǂ݂܂� 
     * 
     */



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
        var random = Random.Range(-90, 91);
        var rb = ball.GetComponent<Rigidbody>();
        var mag = rb.velocity.magnitude;
        var onevector = Quaternion.Euler(0, random, 0) * Vector3.forward;
        

    }
}
