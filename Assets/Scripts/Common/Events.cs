using UnityEngine.Events;

public class Events
{
    public static UnityEvent<string> EventMouseStartHoverItem = new UnityEvent<string>();
    public static UnityEvent EventMouseEndHoverItem = new UnityEvent();
    public static UnityEvent<ItemSlot> EventSelectItem = new UnityEvent<ItemSlot>();
}