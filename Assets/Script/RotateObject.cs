using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Unity��ʂɕ\������
    [SerializeField]
    [Tooltip("x���̉�]�p�x")]
    private float rotateX = 0;

    [SerializeField]
    [Tooltip("y���̉�]�p�x")]
    private float rotateY = 0;

    [SerializeField]
    [Tooltip("z���̉�]�p�x")]
    private float rotateZ = 0;

    [SerializeField]
    [Tooltip("�����̎���")]
    private float moveTime = 0;

    [SerializeField]
    [Tooltip("�I�u�W�F�N�g�̃^�C�v")]
    private bool type = false;

    [SerializeField]
    [Tooltip("�I�u�W�F�N�g�̐i�ތ��� 1->X 2->Y 3->Z")]
    private int num = 0;

    private Vector3 pos;
    void Start()
    {
        // �I�u�W�F�N�g�̍��W��錾�����l�Ƃ��Ďg��
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(num > 3 || num < 1)
        {
            //�w�肵���ԍ��ȊO�𓖂Ă��ꍇX�Ɉړ�����
            num = 1;
        }

        if (!type)
        {
            // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
            // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
            gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
        }
        else
        {
            // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
            // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
            gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
            if(num == 1)
            {
                // X���W��PingPong�֐����g����������悤�ɂ��Ă���
                transform.position = new Vector3(pos.x + Mathf.PingPong(Time.time, moveTime), pos.y, pos.z);
            }
            if (num == 2)
            {
                // Y���W��PingPong�֐����g����������悤�ɂ��Ă���
                transform.position = new Vector3(pos.x, pos.y + Mathf.PingPong(Time.time, moveTime), pos.z);
            }
            if (num == 3)
            {
                // Z���W��PingPong�֐����g����������悤�ɂ��Ă���
                transform.position = new Vector3(pos.x, pos.y, pos.z + Mathf.PingPong(Time.time, moveTime));
            }
        }
    }
}
