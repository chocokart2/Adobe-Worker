using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGoal : MonoBehaviour
{
    TagBundle myTags;

    void DoWhenReachedGoal()
    {
        Debug.Log("�̰��� �����߽��ϴ�!");
    }


    // Start is called before the first frame update
    void Start()
    {
        myTags = GetComponent<TagBundle>();

        myTags.AddAction(DoWhenReachedGoal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
