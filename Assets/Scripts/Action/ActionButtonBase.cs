using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActionButtonBase : MonoBehaviour
{
    public int count; // ���s��
    public bool isenabled = true; // ���s�\��
    public ParameterManager parameterManager;

    public void OnEnable() // �N�������Ƃ��̏���
    {
        CheckEnable();
    }

    public virtual void PushButton() // �{�^�����������Ƃ��̏���
    {
        if (CheckEnable())
        {
            BaseAction(); // ���s�񐔂��L�^
            Debug.Log($"PushButton�����s����܂����B���݂̎��s��: {count}");
        }
        else
        {
            Debug.Log("PushButton�͌��ݖ���������Ă��܂��B");
            ShakeButton(); // �U���A�j���[�V���������s
        }
    }

    public virtual bool CheckEnable()
    {
        return isenabled; // isenabled�̒l��Ԃ�
    }

    public void BaseAction()
    {
        count++; // ���s�񐔂��L�^
    }

    public void ShakeButton()
    {
        // �{�^�����T���߂ɐU��������
        transform.DOShakePosition(0.5f, strength: new Vector3(5f, 0f, 0f), vibrato: 10, randomness: 90, snapping: false, fadeOut: true);
    }
}

