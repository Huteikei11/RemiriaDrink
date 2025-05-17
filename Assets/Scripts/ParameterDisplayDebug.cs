using UnityEngine;
using TMPro;

/// <summary>
/// ParameterManager から Drunk と Sexual の値を取得し、
/// 2つの TextMeshProUGUI に表示するコンポーネント
/// </summary>
public class ParameterDisplayDebug : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private TextMeshProUGUI drunkText;
    [SerializeField] private TextMeshProUGUI sexualText;

    private void Update()
    {
        if (parameterManager == null) return;

        // ParameterManager のプロパティ名は実装に合わせて修正してください
        float drunk = parameterManager.drunk;
        float sexual = parameterManager.sexual;

        if (drunkText != null)
            drunkText.text = $"Drunk: {drunk:F0}";

        if (sexualText != null)
            sexualText.text = $"Sexual: {sexual:F0}";
    }
}
