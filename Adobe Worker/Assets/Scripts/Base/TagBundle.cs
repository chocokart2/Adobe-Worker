using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     32��¥�� �±׸� ��Ʈ����ŷ���� �����ϰ� �浹 ó���� ���ִ� ������Ʈ�Դϴ�.
///     �±״� ����Ƽ�� �±װ� �ƴմϴ�.
/// </summary>
public class TagBundle : MonoBehaviour
{
    [Header("�ܺο��� ������ ���� �±�")]
    [SerializeField] bool fromPlayer;
    [SerializeField] bool fromEnemy;
    [SerializeField] bool fromAttack;
    [SerializeField] bool fromStructure;

    [Header("�ܺο��� �ڽ��� �����ϴ� �±�")]
    [SerializeField] bool player;
    [SerializeField] bool enemy;
    [SerializeField] bool attack;
    [SerializeField] bool structure;
    [SerializeField] List<bool> inspectorInputTags;
    [SerializeField] List<bool> inspectorOutputTags;

    int inputTagValue; // receive tag from other
    int outputTagValue; // insert tag to other
    System.Action tagAction;

    public int GetInputTagID()
    {
        return inputTagValue;
    }
    public void AddInputTag(int tagIndex)
    {
        inputTagValue = inputTagValue | (1 << tagIndex);
    }
    public void RemoveInputTag(int tagIndex)
    {
        inputTagValue &= ~(1 << tagIndex);
    }
    public bool HasInputTag(int tagIndex)
    {
        return (inputTagValue & (1 << tagIndex)) == (1 << tagIndex);
    }
    public int GetOutputTagID()
    {
        return outputTagValue;
    }
    public void AddOutputTag(int tagIndex)
    {
        outputTagValue = outputTagValue | (1 << tagIndex);
    }
    public void RemoveOutputTag(int tagIndex)
    {
        outputTagValue &= ~(1 << tagIndex);
    }
    public bool HasOutputTag(int tagIndex)
    {
        return (outputTagValue & (1 << tagIndex)) == (1 << tagIndex);
    }
    public bool IsSame(TagBundle other)
    {
        return (this.inputTagValue & other.outputTagValue) != 0;
    }
    public void AddAction(System.Action action)
    {
        tagAction += action;
    }

    public void WhenChildCollide(TagBundle other)
    {
        if (IsSame(other))
        {
            tagAction();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        TagBundle otherTag = other.gameObject.GetComponent<TagBundle>();
        if (otherTag == null)
        {
            return;
        }

        if (IsSame(otherTag))
        {
            tagAction();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TagBundle otherTag = collision.gameObject.GetComponent<TagBundle>();
        if (otherTag == null)
        {
            return;
        }

        if (IsSame(otherTag))
        {
            tagAction();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tagAction += () => { };
        if (fromPlayer == true) AddInputTag(0);
        if (fromEnemy == true) AddInputTag(1);
        if (fromAttack == true) AddInputTag(2);
        if (fromStructure == true) AddInputTag(3);

        if (player == true) AddOutputTag(0);
        if (enemy == true) AddOutputTag(1);
        if (attack == true) AddOutputTag(2);
        if (structure == true) AddOutputTag(3);

        for (int index = 0; index < 32 - 4 && index < inspectorInputTags.Count; ++index)
        {
            if (inspectorInputTags[index]) AddInputTag(index + 4);
        }
        for (int index = 0; index < 32 - 4 && index < inspectorOutputTags.Count; ++index)
        {
            if (inspectorOutputTags[index]) AddOutputTag(index + 4);
        }
    }
}
