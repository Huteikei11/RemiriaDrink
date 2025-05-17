using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteGroup
{
    public string groupName; // グループ名 (例: "1-1", "1-2")
    public List<Sprite> sprites; // スプライトのリスト
}

public class RemiriImage : MonoBehaviour
{
    [SerializeField] private List<SpriteGroup> spriteGroups; // SpriteGroupのリスト
    private SpriteRenderer spriteRenderer; // SpriteRendererコンポーネント

    private int currentGroupIndex = -1; // 現在表示中のSpriteGroupのインデックス
    private int currentSpriteIndex = -1; // 現在表示中のSpriteのインデックス

    // Start is called before the first frame update
    void Start()
    {
        // SpriteRendererを取得または追加
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        SetSprite(0, 0);
    }

    /// <summary>
    /// 指定したSpriteGroupとSpriteを表示する
    /// </summary>
    /// <param name="groupIndex">SpriteGroupのインデックス (-1で現在の値を使用)</param>
    /// <param name="spriteIndex">Spriteのインデックス (-1で現在の値を使用)</param>
    public void SetSprite(int groupIndex, int spriteIndex)
    {
        // -1が指定された場合、現在の値を使用
        if (groupIndex == -1)
        {
            groupIndex = currentGroupIndex;
        }

        if (spriteIndex == -1)
        {
            spriteIndex = currentSpriteIndex;
        }

        // インデックスの範囲チェック
        if (groupIndex < 0 || groupIndex >= spriteGroups.Count)
        {
            Debug.LogError("指定されたSpriteGroupのインデックスが範囲外です。");
            return;
        }

        if (spriteIndex < 0 || spriteIndex >= spriteGroups[groupIndex].sprites.Count)
        {
            Debug.LogError("指定されたSpriteのインデックスが範囲外です。");
            return;
        }

        // スプライトを設定
        spriteRenderer.sprite = spriteGroups[groupIndex].sprites[spriteIndex];

        // 現在のインデックスを保存
        currentGroupIndex = groupIndex;
        currentSpriteIndex = spriteIndex;
    }

    /// <summary>
    /// 現在表示中のSpriteGroupのインデックスを取得する
    /// </summary>
    /// <returns>SpriteGroupのインデックス</returns>
    public int GetCurrentGroupIndex()
    {
        return currentGroupIndex;
    }

    /// <summary>
    /// 現在表示中のSpriteのインデックスを取得する
    /// </summary>
    /// <returns>Spriteのインデックス</returns>
    public int GetCurrentSpriteIndex()
    {
        return currentSpriteIndex;
    }
}
