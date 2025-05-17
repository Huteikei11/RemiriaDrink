using UnityEngine;
using TMPro;

/// <summary>
/// ParameterManager ���� Drunk �� Sexual �̒l���擾���A
/// 2�� TextMeshProUGUI �ɕ\������R���|�[�l���g
/// </summary>
public class ParameterDisplayDebug : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private TextMeshProUGUI drunkText;
    [SerializeField] private TextMeshProUGUI sexualText;

    private void Update()
    {
        if (parameterManager == null) return;

        // ParameterManager �̃v���p�e�B���͎����ɍ��킹�ďC�����Ă�������
        float drunk = parameterManager.drunk;
        float sexual = parameterManager.sexual;

        if (drunkText != null)
            drunkText.text = $"Drunk: {drunk:F0}";

        if (sexualText != null)
            sexualText.text = $"Sexual: {sexual:F0}";
    }
}
