using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ActionButtonBaseから継承しているので気を付けてください
public class MassageHand : ActionButtonBase
{

    public override void PushButton()//ボタンを押したときの処理
    {
        if (CheckEnable())
        {
            //演出ここから



            //演出ここまで

            //parameter加算。酔い,性,好感度
            parameterManager.AddParameter(2,5,0);
            //実行回数の加算
            BaseAction();
        }
    }

    //実行可能な条件を記述
    public override bool CheckEnable()
    {
        isenabled = true;
        return true;
    }
}
