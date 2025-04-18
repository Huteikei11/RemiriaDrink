using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ActionButton : ActionButtonBase
{
    [SerializeField] private Image actionImage; // 共有の画像
    [SerializeField] private Sprite actionSprite; // Inspectorから設定する適用する画像
    [SerializeField] private float displayDuration = 2f; // 画像を表示する時間
    [SerializeField] private float fadeDelay = 2f; // フェードアウト前の待機時間

    // Inspectorから設定可能なパラメータ
    [SerializeField] private float addDrunk = 10f; // 酔いの値
    [SerializeField] private float addSexual = 5f; // 性的な値
    [SerializeField] private float addLikeability = 3f; // 好感度の値

    private static Tween currentTween; // 共有のDOTweenアニメーションを管理

    public override void PushButton() // 引数なしのPushButton
    {
        if (CheckEnable())
        {
            BaseAction();
            Debug.Log($"PushButtonが実行されました。現在の実行回数: {count}");

            if (actionImage != null)
            {
                ApplySpriteToImage();
                ShowActionImage();
            }

            if (parameterManager != null)
            {
                parameterManager.AddParameter(addDrunk, addSexual, addLikeability); // Inspectorで設定した値を使用
            }
        }
        else
        {
            Debug.Log("PushButtonは現在無効化されています。");
        }
    }

    private void ApplySpriteToImage()
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

        Debug.Log($"actionImageに適用するSprite: {actionSprite.name}");
        actionImage.sprite = actionSprite;

        if (actionImage.sprite == actionSprite)
        {
            Debug.Log("Spriteが正常に適用されました。");
        }
        else
        {
            Debug.LogError("Spriteの適用に失敗しました。");
        }
    }

    private void ShowActionImage()
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

