using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ActionButton : MonoBehaviour
{
    /*
    * パラメータの変更、カットインの表示機能がついています。
    * 実行条件、服を脱がすなどの個別の処理は継承して実装してください。
    * 
    * ActionButtonクラスは、ActionButtonBaseクラスを継承し、ボタンが押されたときの処理を実装します。
    * 具体的には、ParameterManagerを使用してパラメータを加算し、DOTweenを使用して画像のフェードイン・フェードアウトを行います。
    *
    * public int count; // 実行回数
    * public bool isenabled = true; // 実行可能か
    * public ParameterManager parameterManager;
    */
    public Image actionImage; // カットインを表示するのにつかう共有の画像。
    public   Sprite actionSprite; // Inspectorから設定する適用する画像
    public float displayDuration = 2f; // 画像を表示する時間
    public float fadeDelay = 2f; // フェードアウト前の待機時間

    // Inspectorから設定可能なパラメータ
    public float addDrunk = 10f; // 酔いの値
    public float addSexual = 5f; // 性的な値
    public float addLikeability = 3f; // 好感度の値

    protected static Tween currentTween; // 共有のDOTweenアニメーションを管理

    public virtual void PushButton() // ボタンが押されたときの処理
    {
        if (CheckExecutionCondition())
        {
            ExecuteAction(); // 実行内容をオーバーライド可能
            Debug.Log("PushButtonが実行されました。");
        }
        else
        {
            Debug.Log("実行条件が満たされていません。");
        }
    }

    /// <summary>
    /// 実行条件を検証するメソッド。継承先でオーバーライド可能。
    /// </summary>
    /// <returns>実行可能かどうかを返す</returns>
    protected virtual bool CheckExecutionCondition()
    {
        // デフォルトでは常に実行可能
        return true;
    }

    /// <summary>
    /// ボタンが押されたときの演出を記述するメソッド。継承先でオーバーライド可能。
    /// </summary>
    protected virtual void ExecuteAction()
    {
        // デフォルトの演出
        if (actionImage != null)
        {
            ApplySpriteToImage();
            ShowActionImage();
        }
    }

    public void ApplySpriteToImage()
    {
        if (actionImage == null)
        {
            Debug.LogError("actionImageが設定されていません。");
            return;
        }

        if (actionSprite == null)
        {
            Debug.LogError("actionSpriteが設定されていません。");
            return;
        }

        actionImage.sprite = actionSprite;
    }

    public void ShowActionImage()
    {
        // 前回のアニメーションを停止
        if (currentTween != null && currentTween.IsActive())
        {
            currentTween.Kill();
        }

        actionImage.gameObject.SetActive(true);
        actionImage.color = new Color(actionImage.color.r, actionImage.color.g, actionImage.color.b, 1f);

        // フェードアウト前に数秒間待機
        currentTween = actionImage.DOFade(1f, fadeDelay) // 透明度を変えずに待機
            .OnComplete(() =>
            {
                // 待機後にフェードアウト
                currentTween = actionImage.DOFade(0f, displayDuration).OnComplete(() =>
                {
                    actionImage.gameObject.SetActive(false);
                });
            });
    }
}
