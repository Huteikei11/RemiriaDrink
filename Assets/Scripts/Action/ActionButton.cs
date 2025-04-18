using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ActionButton : ActionButtonBase
{
    [SerializeField] private Image actionImage; // ���L�̉摜
    [SerializeField] private Sprite actionSprite; // Inspector����ݒ肷��K�p����摜
    [SerializeField] private float displayDuration = 2f; // �摜��\�����鎞��
    [SerializeField] private float fadeDelay = 2f; // �t�F�[�h�A�E�g�O�̑ҋ@����

    // Inspector����ݒ�\�ȃp�����[�^
    [SerializeField] private float addDrunk = 10f; // �����̒l
    [SerializeField] private float addSexual = 5f; // ���I�Ȓl
    [SerializeField] private float addLikeability = 3f; // �D���x�̒l

    private static Tween currentTween; // ���L��DOTween�A�j���[�V�������Ǘ�

    public override void PushButton() // �����Ȃ���PushButton
    {
        if (CheckEnable())
        {
            BaseAction();
            Debug.Log($"PushButton�����s����܂����B���݂̎��s��: {count}");

            if (actionImage != null)
            {
                ApplySpriteToImage();
                ShowActionImage();
            }

            if (parameterManager != null)
            {
                parameterManager.AddParameter(addDrunk, addSexual, addLikeability); // Inspector�Őݒ肵���l���g�p
            }
        }
        else
        {
            Debug.Log("PushButton�͌��ݖ���������Ă��܂��B");
        }
    }

    private void ApplySpriteToImage()
    {
        if (actionImage == null)
        {
            Debug.LogError("actionImage���ݒ肳��Ă��܂���B");
            return;
        }

        if (actionSprite == null)
        {
            Debug.LogError("actionSprite���ݒ肳��Ă��܂���B");
            return;
        }

        Debug.Log($"actionImage�ɓK�p����Sprite: {actionSprite.name}");
        actionImage.sprite = actionSprite;

        if (actionImage.sprite == actionSprite)
        {
            Debug.Log("Sprite������ɓK�p����܂����B");
        }
        else
        {
            Debug.LogError("Sprite�̓K�p�Ɏ��s���܂����B");
        }
    }

    private void ShowActionImage()
    {
        // �O��̃A�j���[�V�������~
        if (currentTween != null && currentTween.IsActive())
        {
            currentTween.Kill();
        }

        actionImage.gameObject.SetActive(true);
        actionImage.color = new Color(actionImage.color.r, actionImage.color.g, actionImage.color.b, 1f);

        // �t�F�[�h�A�E�g�O�ɐ��b�ԑҋ@
        currentTween = actionImage.DOFade(1f, fadeDelay) // �����x��ς����ɑҋ@
            .OnComplete(() =>
            {
                // �ҋ@��Ƀt�F�[�h�A�E�g
                currentTween = actionImage.DOFade(0f, displayDuration).OnComplete(() =>
                {
                    actionImage.gameObject.SetActive(false);
                });
            });
    }
}

