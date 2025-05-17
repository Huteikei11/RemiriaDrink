using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteGroup
{
    public string groupName; // �O���[�v�� (��: "1-1", "1-2")
    public List<Sprite> sprites; // �X�v���C�g�̃��X�g
}

public class RemiriImage : MonoBehaviour
{
    [SerializeField] private List<SpriteGroup> spriteGroups; // SpriteGroup�̃��X�g
    private SpriteRenderer spriteRenderer; // SpriteRenderer�R���|�[�l���g

    private int currentGroupIndex = -1; // ���ݕ\������SpriteGroup�̃C���f�b�N�X
    private int currentSpriteIndex = -1; // ���ݕ\������Sprite�̃C���f�b�N�X

    // Start is called before the first frame update
    void Start()
    {
        // SpriteRenderer���擾�܂��͒ǉ�
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        SetSprite(0, 0);
    }

    /// <summary>
    /// �w�肵��SpriteGroup��Sprite��\������
    /// </summary>
    /// <param name="groupIndex">SpriteGroup�̃C���f�b�N�X (-1�Ō��݂̒l���g�p)</param>
    /// <param name="spriteIndex">Sprite�̃C���f�b�N�X (-1�Ō��݂̒l���g�p)</param>
    public void SetSprite(int groupIndex, int spriteIndex)
    {
        // -1���w�肳�ꂽ�ꍇ�A���݂̒l���g�p
        if (groupIndex == -1)
        {
            groupIndex = currentGroupIndex;
        }

        if (spriteIndex == -1)
        {
            spriteIndex = currentSpriteIndex;
        }

        // �C���f�b�N�X�͈̔̓`�F�b�N
        if (groupIndex < 0 || groupIndex >= spriteGroups.Count)
        {
            Debug.LogError("�w�肳�ꂽSpriteGroup�̃C���f�b�N�X���͈͊O�ł��B");
            return;
        }

        if (spriteIndex < 0 || spriteIndex >= spriteGroups[groupIndex].sprites.Count)
        {
            Debug.LogError("�w�肳�ꂽSprite�̃C���f�b�N�X���͈͊O�ł��B");
            return;
        }

        // �X�v���C�g��ݒ�
        spriteRenderer.sprite = spriteGroups[groupIndex].sprites[spriteIndex];

        // ���݂̃C���f�b�N�X��ۑ�
        currentGroupIndex = groupIndex;
        currentSpriteIndex = spriteIndex;
    }

    /// <summary>
    /// ���ݕ\������SpriteGroup�̃C���f�b�N�X���擾����
    /// </summary>
    /// <returns>SpriteGroup�̃C���f�b�N�X</returns>
    public int GetCurrentGroupIndex()
    {
        return currentGroupIndex;
    }

    /// <summary>
    /// ���ݕ\������Sprite�̃C���f�b�N�X���擾����
    /// </summary>
    /// <returns>Sprite�̃C���f�b�N�X</returns>
    public int GetCurrentSpriteIndex()
    {
        return currentSpriteIndex;
    }
}
