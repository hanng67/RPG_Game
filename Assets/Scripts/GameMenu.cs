using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject canvasObject;
    [SerializeField] private GameObject playerStatusWindow;
    [SerializeField] private GameObject bagWindow;

    private void Update()
    {
        if (!Input.GetButtonDown("Fire2")) return;

        if (canvasObject.activeInHierarchy) CloseGameMenu();
        else OpenGameMenu();
    }

    private void OpenGameMenu()
    {
        canvasObject.SetActive(true);
        GameManager.Instance.gameMenuOpen = true;
    }

    public void CloseGameMenu()
    {
        playerStatusWindow.SetActive(true);
        bagWindow.SetActive(false);
        canvasObject.SetActive(false);
        GameManager.Instance.gameMenuOpen = false;
    }

    public void OnBagButtonClick()
    {
        bool isBagWindowOpen = bagWindow.activeInHierarchy;
        playerStatusWindow.SetActive(isBagWindowOpen);
        bagWindow.SetActive(!isBagWindowOpen);
    }
}
