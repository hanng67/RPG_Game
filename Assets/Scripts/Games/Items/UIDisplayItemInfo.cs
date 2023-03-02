using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayItemInfo : MonoBehaviour
{
    [SerializeField] private GameObject popupCanvasObject = null;
    public RectTransform HoverInfoPopup;
    public Text TextInfo;
    [SerializeField] private Vector3 offset = new Vector3(0, -50, 0);
    [SerializeField] private int padding = 25;

    private Canvas popupCanvas;

    private void Start()
    {
        popupCanvas = popupCanvasObject.GetComponent<Canvas>();
        Events.EventMouseStartHoverItem.AddListener(DisplayInfo);
        Events.EventMouseEndHoverItem.AddListener(HideInfo);
    }
    private void Update() => FollowCursor();
    public void HideInfo() => popupCanvasObject.SetActive(false);

    public void DisplayInfo(string itemInfo)
    {
        TextInfo.text = itemInfo;
        popupCanvasObject.SetActive(true);
    }

    public void FollowCursor()
    {
        if (!popupCanvasObject.activeSelf) return;

        Vector3 newPos = Input.mousePosition + (popupCanvas.scaleFactor * offset);
        newPos.z = 0f;

        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupCanvas.scaleFactor * ((HoverInfoPopup.rect.width / 2) + padding));
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }

        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupCanvas.scaleFactor * ((HoverInfoPopup.rect.width / 2) + padding));
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }

        float bottomEdgeToScreenEdgeDistance = 0 - (newPos.y - popupCanvas.scaleFactor * (HoverInfoPopup.rect.height + padding));
        if (bottomEdgeToScreenEdgeDistance > 0)
        {
            newPos.y += bottomEdgeToScreenEdgeDistance;
        }

        HoverInfoPopup.position = newPos;
    }
}
