using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActionButtonBase : MonoBehaviour
{
    public int count; // 実行回数
    public bool isenabled = true; // 実行可能か
    public ParameterManager parameterManager;

    public void OnEnable() // 起動したときの処理
    {
        CheckEnable();
    }

    public virtual void PushButton() // ボタンを押したときの処理
    {
        if (CheckEnable())
        {
            BaseAction(); // 実行回数を記録
            Debug.Log($"PushButtonが実行されました。現在の実行回数: {count}");
        }
        else
        {
            Debug.Log("PushButtonは現在無効化されています。");
            ShakeButton(); // 振動アニメーションを実行
        }
    }

    public virtual bool CheckEnable()
    {
        return isenabled; // isenabledの値を返す
    }

    public void BaseAction()
    {
        count++; // 実行回数を記録
    }

    public void ShakeButton()
    {
        // ボタンを控えめに振動させる
        transform.DOShakePosition(0.5f, strength: new Vector3(5f, 0f, 0f), vibrato: 10, randomness: 90, snapping: false, fadeOut: true);
    }
}

