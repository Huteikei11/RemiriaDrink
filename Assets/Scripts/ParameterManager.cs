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

    //parameter�����Z�B���̃I�u�W�F�N�g����Ăяo��
    public void AddParameter(float adddrunk,float addsexual,float addlikeability)
    {
        drunk = Mathf.Clamp(drunk+adddrunk,0, 100);
        sexual = Mathf.Clamp(sexual + addsexual, 0, 100);
        likeability = Mathf.Clamp(likeability + addlikeability, 0, 100);

        AdvanceTurn();//turn��i�߂鏈��
    }

    private void AdvanceTurn()
    {
        turn++;

        if (!CheckGameOver())//�Q�[���I�[�o�[�Ȃ�Ⓒ������X�L�b�v
        {
            CheckEcstasy();//�Ⓒ�`�F�b�N
        }
    }

    private bool CheckEcstasy()
    {
        if(sexual >= 100)
        {
            //�Ⓒ���o
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
        if(drunk >= 100)//����100%
        {
            GameOverAlcoholic();
            return true;
        }
        else if(drunk <= 0)//�������߂�
        {
            GameOverCalm();
            return true;
        }
        else if (sexual >= 100)// ��MAX
        {
            GameOverSexual();
            return true;
        }

        return false;
    }

    private void GameOverAlcoholic()//����100%
    {
        Debug.Log("������MAX�I�I�G�[�I�I�I");
        if (gameOverAction != null)
        {
            gameOverAction.ShowAlcoholicPanel();
        }
    }

    private void GameOverCalm()
    {
        Debug.Log("���������߂܂����B");
        if (gameOverAction != null)
        {
            gameOverAction.ShowCalmPanel();
        }
    }

    private void GameOverSexual()
    {
        Debug.Log("���I�ȋ�����MAX�ł��B");
        if (gameOverAction != null)
        {
            gameOverAction.ShowSexualPanel();
        }
    }


}
