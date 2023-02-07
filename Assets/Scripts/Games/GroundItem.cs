using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public ItemInfo Item;
    [SerializeField] private SpriteRenderer icon;

    // private void Start() {
    //     icon.sprite = item.Stats?.Sprite;
    // }

    private void OnValidate()
    {
        transform.name = Item.Stats == null ? "GroundItem" : Item.Stats.Name;
        icon.sprite = Item.Stats?.Sprite;
    }
}
