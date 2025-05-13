using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ActionButton : MonoBehaviour
{
    /*
    * �p�����[�^�̕ύX�A�J�b�g�C���̕\���@�\�����Ă��܂��B
    * ���s�����A����E�����Ȃǂ̌ʂ̏����͌p�����Ď������Ă��������B
    * 
    * ActionButton�N���X�́AActionButtonBase�N���X���p�����A�{�^���������ꂽ�Ƃ��̏������������܂��B
    * ��̓I�ɂ́AParameterManager���g�p���ăp�����[�^�����Z���ADOTween���g�p���ĉ摜�̃t�F�[�h�C���E�t�F�[�h�A�E�g���s���܂��B
    *
    * public int count; // ���s��
    * public bool isenabled = true; // ���s�\��
    * public ParameterManager parameterManager;
    */
    public Image actionImage; // �J�b�g�C����\������̂ɂ������L�̉摜�B
    public   Sprite actionSprite; // Inspector����ݒ肷��K�p����摜
    public float displayDuration = 2f; // �摜��\�����鎞��
    public float fadeDelay = 2f; // �t�F�[�h�A�E�g�O�̑ҋ@����

    // Inspector����ݒ�\�ȃp�����[�^
    public float addDrunk = 10f; // �����̒l
    public float addSexual = 5f; // ���I�Ȓl
    public float addLikeability = 3f; // �D���x�̒l

    protected static Tween currentTween; // ���L��DOTween�A�j���[�V�������Ǘ�

    public virtual void PushButton() // �{�^���������ꂽ�Ƃ��̏���
    {
        if (CheckExecutionCondition())
        {
            ExecuteAction(); // ���s���e���I�[�o�[���C�h�\
            Debug.Log("PushButton�����s����܂����B");
        }
        else
        {
            Debug.Log("���s��������������Ă��܂���B");
        }
    }

    /// <summary>
    /// ���s���������؂��郁�\�b�h�B�p����ŃI�[�o�[���C�h�\�B
    /// </summary>
    /// <returns>���s�\���ǂ�����Ԃ�</returns>
    protected virtual bool CheckExecutionCondition()
    {
        // �f�t�H���g�ł͏�Ɏ��s�\
        return true;
    }

    /// <summary>
    /// �{�^���������ꂽ�Ƃ��̉��o���L�q���郁�\�b�h�B�p����ŃI�[�o�[���C�h�\�B
    /// </summary>
    protected virtual void ExecuteAction()
    {
        // �f�t�H���g�̉��o
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
            Debug.LogError("actionImage���ݒ肳��Ă��܂���B");
            return;
        }

        if (actionSprite == null)
        {
            Debug.LogError("actionSprite���ݒ肳��Ă��܂���B");
            return;
        }

        actionImage.sprite = actionSprite;
    }

    public void ShowActionImage()
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
