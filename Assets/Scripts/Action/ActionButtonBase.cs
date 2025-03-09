using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonBase : MonoBehaviour
{
    public int count; //実行回数
    public bool isenabled; //実行可能か
    public ParameterManager parameterManager;

    public void OnEnable()//起動したときの処理
    {
       CheckEnable();
    }

    public virtual void PushButton()//ボタンを押したときの処理
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
