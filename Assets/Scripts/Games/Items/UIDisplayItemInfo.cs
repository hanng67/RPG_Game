using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayItemInfo : MonoBehaviour
{
    public RectTransform HoverInfoPopup;
    public Text TextInfo;
    [SerializeField] private Vector3 offset = new Vector3(0, 50, 0);
    [SerializeField] private int padding = 25;

    private Canvas popupRange;

    private void Start()
    {
        popupRange = GetComponentInParent<Canvas>();
        Events.EventMouseStartHoverItem.AddListener(DisplayInfo);
        Events.EventMouseEndHoverItem.AddListener(HideInfo);
    }
    private void Update() => FollowCursor();
    public void HideInfo() => HoverInfoPopup.gameObject.SetActive(false);

    public void DisplayInfo(string itemInfo)
    {
        TextInfo.text = itemInfo;
        HoverInfoPopup.gameObject.SetActive(true);
    }

    public void FollowCursor()
    {
        if (!HoverInfoPopup.gameObject.activeSelf) return;

        Vector3 newPos = Input.mousePosition + offset;
        newPos.z = 0f;

        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + HoverInfoPopup.rect.width * popupRange.scaleFactor / 2) - padding;
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }

        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - HoverInfoPopup.rect.width * popupRange.scaleFactor / 2) + padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }

        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.x + HoverInfoPopup.rect.height * popupRange.scaleFactor / 2) - padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += topEdgeToScreenEdgeDistance;
        }

        HoverInfoPopup.position = newPos;
    }
}
