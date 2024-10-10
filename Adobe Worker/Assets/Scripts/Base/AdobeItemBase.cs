using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AdobeItemBase : MonoBehaviour
{
    [TextArea]
    [Tooltip("�� ��Ʈ���� �ڵ� �󿡼� �ƹ� ¦���� ���� ������, ��� �ν����Ϳ��� �ּ� ������ �մϴ�.")]
    public string memo;

    public int id;
    public int amount;

    public virtual void Use(AdobeItemUseArguments arguments)
    {
        Debug.Log($"{gameObject.name} : �������� ����߽��ϴ�.");
    }
}
