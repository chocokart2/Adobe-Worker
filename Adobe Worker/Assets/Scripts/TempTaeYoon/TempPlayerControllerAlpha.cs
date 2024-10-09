using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TempPlayerControllerAlpha : MonoBehaviour
{
    AdobeItemPack inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<AdobeItemPack>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f,
            0,
            Input.GetAxis("Vertical") * Time.deltaTime * 3.0f));

        UseItems();
        ShowInventory();
    }

    void UseItems()
    {
        if (Input.GetKeyDown(KeyCode.U) == false)
        {
            return;
        }

        AdobeItemUseArguments args = new AdobeItemUseArguments();
        inventory.Use(args);
    }

    void SwitchItems()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inventory.SwitchItem(-1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inventory.SwitchItem(1);
        }

        Debug.Log($"�������� �ٲپ����ϴ�. ���� : {inventory.inventoryIndex} {inventory.inventory[inventory.inventoryIndex].id}");
    }

    void ShowInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) == false)
        {
            return;
        }

        StringBuilder answer = new StringBuilder();
        foreach (AdobeItemBase item in inventory.inventory)
        {
            answer.AppendLine($"[������ ���̵� {item.id}, ������ ���� {item.amount}]");
        }

        Debug.Log(answer.ToString());
    }

    void TempItemSet()
    {
        AdobeItemBase tempItem = new AdobeItemBase();
        tempItem.id = 1;
        tempItem.amount = 3;

        inventory.inventory.Add(tempItem);
    }
}
