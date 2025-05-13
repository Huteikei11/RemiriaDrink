using UnityEngine;

public class CustomActionButton : ActionButton
{
    /*
     * �ȉ��́AActionButton ���p������V�����N���X CustomActionButton �̗�ł��B
     * ���̃N���X�ł́A�p�����̃p�����[�^��ϐ����R�����g�Ƃ��ċL�ڂ��A�ҏW���₷���悤�ɂ��Ă��܂��B
     * 
     *  �p���� �̌�(ActionButtonBase) �̃p�����[�^�ƕϐ�:
     *  public int count; // ���s��
     *  public bool isenabled = true; // ���s�\��
     * public ParameterManager parameterManager;
     * 
     * �p���� (ActionButton) �̃p�����[�^�ƕϐ�:
     * 
     * public Image actionImage; // �J�b�g�C����\������̂ɂ������L�̉摜
     * public Sprite actionSprite; // Inspector����ݒ肷��K�p����摜
     * public float displayDuration = 2f; // �摜��\�����鎞��
     * public float fadeDelay = 2f; // �t�F�[�h�A�E�g�O�̑ҋ@����
     * public float addDrunk = 10f; // �����̒l
     * public float addSexual = 5f; // ���I�Ȓl
     * public addLikeability = 3f; // �D���x�̒l
     * private static Tween currentTween; // ���L��DOTween�A�j���[�V�������Ǘ�
     */
    public ParameterManager parameterManager; // �p�����[�^���Ǘ�����N���X�̃C���X�^���X

    /// <summary>
    /// ���s�������J�X�^�}�C�Y���郁�\�b�h�B
    /// </summary>
    /// <returns>���s�\���ǂ�����Ԃ�</returns>
    protected override bool CheckExecutionCondition()
    {
        // ��: �����̒l��50�ȏ�̏ꍇ�̂ݎ��s�\
        if (parameterManager != null && parameterManager.drunk >= 50)
        {
            return true;
        }

        Debug.Log("���s��������������Ă��܂��� (�����̒l���s�����Ă��܂�)�B");
        return false;
    }

    /// <summary>
    /// �{�^���������ꂽ�Ƃ��̉��o���J�X�^�}�C�Y���郁�\�b�h�B
    /// </summary>
    protected override void ExecuteAction()
    {
        // �p�����̃f�t�H���g�̉��o�����s
        base.ExecuteAction();

        // �J�X�^�����o��ǉ�
        Debug.Log("CustomActionButton: �J�X�^�����o�����s���܂��I");

        // ��: ����̃I�u�W�F�N�g����]������
        if (actionImage != null)
        {
            actionImage.transform.Rotate(Vector3.forward, 45f);
        }
    }
}
