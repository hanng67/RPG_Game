using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public ItemSlot ItemSlot;
    [SerializeField] private SpriteRenderer icon;

    private void OnValidate()
    {
        transform.name = ItemSlot.Item == null ? "GroundItem" : ItemSlot.Item.Name;
        icon.sprite = ItemSlot.Item?.Icon;
    }

    private void Reset() {
        icon = GetComponentInChildren<SpriteRenderer>();
    }
}
