using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    public float drunk;
    public float sexual;
    public float likeability;

    public int turn;
    public int ecstasyNum;

    [SerializeField] private GameOverAction gameOverAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //parameterを加算。他のオブジェクトから呼び出す
    public void AddParameter(float adddrunk,float addsexual,float addlikeability)
    {
        drunk = Mathf.Clamp(drunk+adddrunk,0, 100);
        sexual = Mathf.Clamp(sexual + addsexual, 0, 100);
        likeability = Mathf.Clamp(likeability + addlikeability, 0, 100);

        AdvanceTurn();//turnを進める処理
    }

    private void AdvanceTurn()
    {
        turn++;

        if (!CheckGameOver())//ゲームオーバーなら絶頂判定をスキップ
        {
            CheckEcstasy();//絶頂チェック
        }
    }

    private bool CheckEcstasy()
    {
        if(sexual >= 100)
        {
            //絶頂演出
            EcstasyPerformance();
            return true;
        }
        return false;

    }

    private void EcstasyPerformance()
    {

    }

    private bool CheckGameOver()
    {
        if(drunk >= 100)//酔い100%
        {
            GameOverAlcoholic();
            return true;
        }
        else if(drunk <= 0)//酔いさめた
        {
            GameOverCalm();
            return true;
        }
        else if (sexual >= 100)// 性MAX
        {
            GameOverSexual();
            return true;
        }

        return false;
    }

    private void GameOverAlcoholic()//酔い100%
    {
        Debug.Log("酔いがMAX！オエー！！！");
        if (gameOverAction != null)
        {
            gameOverAction.ShowAlcoholicPanel();
        }
    }

    private void GameOverCalm()
    {
        Debug.Log("酔いがさめました。");
        if (gameOverAction != null)
        {
            gameOverAction.ShowCalmPanel();
        }
    }

    private void GameOverSexual()
    {
        Debug.Log("性的な興奮がMAXです。");
        if (gameOverAction != null)
        {
            gameOverAction.ShowSexualPanel();
        }
    }


}
