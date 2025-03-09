using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonBase : MonoBehaviour
{
    public int count; //���s��
    public bool isenabled; //���s�\��
    public ParameterManager parameterManager;

    public void OnEnable()//�N�������Ƃ��̏���
    {
       CheckEnable();
    }

    public virtual void PushButton()//�{�^�����������Ƃ��̏���
    {
        if (CheckEnable()) 
        {
            
        }
    }

    public virtual bool CheckEnable()
    {
        return true;
    }

    public void BaseAction()
    {
        count++;
    }
}
