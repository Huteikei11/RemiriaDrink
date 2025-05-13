using UnityEngine;

public class CustomActionButton : ActionButton
{
    /*
     * 以下は、ActionButton を継承する新しいクラス CustomActionButton の例です。
     * このクラスでは、継承元のパラメータや変数をコメントとして記載し、編集しやすいようにしています。
     * 
     *  継承元 の元(ActionButtonBase) のパラメータと変数:
     *  public int count; // 実行回数
     *  public bool isenabled = true; // 実行可能か
     * public ParameterManager parameterManager;
     * 
     * 継承元 (ActionButton) のパラメータと変数:
     * 
     * public Image actionImage; // カットインを表示するのにつかう共有の画像
     * public Sprite actionSprite; // Inspectorから設定する適用する画像
     * public float displayDuration = 2f; // 画像を表示する時間
     * public float fadeDelay = 2f; // フェードアウト前の待機時間
     * public float addDrunk = 10f; // 酔いの値
     * public float addSexual = 5f; // 性的な値
     * public addLikeability = 3f; // 好感度の値
     * private static Tween currentTween; // 共有のDOTweenアニメーションを管理
     */
    public ParameterManager parameterManager; // パラメータを管理するクラスのインスタンス

    /// <summary>
    /// 実行条件をカスタマイズするメソッド。
    /// </summary>
    /// <returns>実行可能かどうかを返す</returns>
    protected override bool CheckExecutionCondition()
    {
        // 例: 酔いの値が50以上の場合のみ実行可能
        if (parameterManager != null && parameterManager.drunk >= 50)
        {
            return true;
        }

        Debug.Log("実行条件が満たされていません (酔いの値が不足しています)。");
        return false;
    }

    /// <summary>
    /// ボタンが押されたときの演出をカスタマイズするメソッド。
    /// </summary>
    protected override void ExecuteAction()
    {
        // 継承元のデフォルトの演出を実行
        base.ExecuteAction();

        // カスタム演出を追加
        Debug.Log("CustomActionButton: カスタム演出を実行します！");

        // 例: 特定のオブジェクトを回転させる
        if (actionImage != null)
        {
            actionImage.transform.Rotate(Vector3.forward, 45f);
        }
    }
}
