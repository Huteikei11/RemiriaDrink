using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ActionButtonBase����p�����Ă���̂ŋC��t���Ă�������
public class MassageHand : ActionButtonBase
{

    public override void PushButton()//�{�^�����������Ƃ��̏���
    {
        if (CheckEnable())
        {
            //���o��������



            //���o�����܂�

            //parameter���Z�B����,��,�D���x
            parameterManager.AddParameter(2,5,0);
            //���s�񐔂̉��Z
            BaseAction();
        }
    }

    //���s�\�ȏ������L�q
    public override bool CheckEnable()
    {
        isenabled = true;
        return true;
    }
}
