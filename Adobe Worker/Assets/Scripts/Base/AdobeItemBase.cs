using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AdobeItemBase : MonoBehaviour
{
    public int id;
    public int amount;

    public virtual void Use(AdobeItemUseArguments arguments)
    {
        Debug.Log($"{gameObject.name} : �������� ����߽��ϴ�.");
    }
}
