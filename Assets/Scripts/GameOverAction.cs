using UnityEngine;

/// <summary>
/// ゲームオーバー時に対応するパネルを表示するスクリプト
/// </summary>
public class GameOverAction : MonoBehaviour
{
    [Header("ゲームオーバー時に表示するパネル")]
    [SerializeField] private GameObject alcoholicPanel;   // 酔い100%用
    [SerializeField] private GameObject calmPanel;        // 酔い0%用
    [SerializeField] private GameObject sexualPanel;      // 性的興奮100%用

    /// <summary>
    /// 酔い100%のゲームオーバー時に呼び出す
    /// </summary>

    private void Start()
    {
        // 初期化処理
        HideAllPanels();
    }
    public void ShowAlcoholicPanel()
    {
        // HideAllPanels();
        if (alcoholicPanel != null)
            alcoholicPanel.SetActive(true);
    }

    /// <summary>
    /// 酔い0%のゲームオーバー時に呼び出す
    /// </summary>
    public void ShowCalmPanel()
    {
        HideAllPanels();
        if (calmPanel != null)
            calmPanel.SetActive(true);
    }

    /// <summary>
    /// 性的興奮100%のゲームオーバー時に呼び出す
    /// </summary>
    public void ShowSexualPanel()
    {
        HideAllPanels();
        if (sexualPanel != null)
            sexualPanel.SetActive(true);
    }

    /// <summary>
    /// すべてのパネルを非表示にする
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
