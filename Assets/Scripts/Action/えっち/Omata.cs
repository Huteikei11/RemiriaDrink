using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Omata : ActionButton
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
     * public Image attachedImage; // スクリプトがアタッチされているImage
     */

    /// <summary>
    /// 実行条件をカスタマイズするメソッド。
    /// </summary>
    /// <returns>実行可能かどうかを返す</returns>
    [SerializeField] private RemiriImage remiriImage; // RemiriImageの参照
    [SerializeField] private List<Sprite> sprites;    // Mune専用のSpriteリスト

    /// <summary>
    /// 実行条件をカスタマイズするメソッド。
    /// </summary>
    /// <returns>実行可能かどうかを返す</returns>
    protected override bool CheckExecutionCondition()
    {
        if (parameterManager != null && parameterManager.sexual >= 50)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// ボタンが押されたときの演出をカスタマイズするメソッド。
    /// </summary>
    protected override void ExecuteAction()
    {

        // RemiriImageのcurrentSpriteIndexを取得し、spritesリストからactionSpriteを切り替え
        if (remiriImage != null && sprites != null && sprites.Count > 0)
        {
            int spriteIndex = remiriImage.GetCurrentSpriteIndex();
            if (spriteIndex >= 0 && spriteIndex < sprites.Count)
            {
                actionSprite = sprites[spriteIndex];
                ApplySpriteToImage(); // actionImageに反映
            }
            else
            {
                Debug.LogWarning("Mune: spriteIndexがリスト範囲外です。");
            }
        }

        base.ExecuteAction();
    }
}
