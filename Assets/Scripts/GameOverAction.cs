using UnityEngine;

/// <summary>
/// �Q�[���I�[�o�[���ɑΉ�����p�l����\������X�N���v�g
/// </summary>
public class GameOverAction : MonoBehaviour
{
    [Header("�Q�[���I�[�o�[���ɕ\������p�l��")]
    [SerializeField] private GameObject alcoholicPanel;   // ����100%�p
    [SerializeField] private GameObject calmPanel;        // ����0%�p
    [SerializeField] private GameObject sexualPanel;      // ���I����100%�p

    /// <summary>
    /// ����100%�̃Q�[���I�[�o�[���ɌĂяo��
    /// </summary>

    private void Start()
    {
        // ����������
        HideAllPanels();
    }
    public void ShowAlcoholicPanel()
    {
        // HideAllPanels();
        if (alcoholicPanel != null)
            alcoholicPanel.SetActive(true);
    }

    /// <summary>
    /// ����0%�̃Q�[���I�[�o�[���ɌĂяo��
    /// </summary>
    public void ShowCalmPanel()
    {
        HideAllPanels();
        if (calmPanel != null)
            calmPanel.SetActive(true);
    }

    /// <summary>
    /// ���I����100%�̃Q�[���I�[�o�[���ɌĂяo��
    /// </summary>
    public void ShowSexualPanel()
    {
        HideAllPanels();
        if (sexualPanel != null)
            sexualPanel.SetActive(true);
    }

    /// <summary>
    /// ���ׂẴp�l�����\���ɂ���
    /// </summary>
    private void HideAllPanels()
    {
        if (alcoholicPanel != null)
            alcoholicPanel.SetActive(false);
        if (calmPanel != null)
            calmPanel.SetActive(false);
        if (sexualPanel != null)
            sexualPanel.SetActive(false);
    }
}
