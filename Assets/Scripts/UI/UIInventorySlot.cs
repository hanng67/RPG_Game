using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySlot : MonoBehaviour
{
    public Image ItemImage;
    public Text TxtAmount;

    public void UpdateInfo(Sprite itemSprite = null, string amount = "")
    {
        ItemImage.gameObject.SetActive(itemSprite);
        ItemImage.sprite = itemSprite;
        TxtAmount.text = amount;
    }
}
