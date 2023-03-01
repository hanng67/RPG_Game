using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr Instance;

    public UIFade UIFadeSystem;
    public DialogManager UIDialogSystem;
    public GameMenu UIGameMenu;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        CheckOpenGameMenuAction();
    }

    private void CheckOpenGameMenuAction()
    {
        if (!Input.GetButtonDown("Fire2")) return;

        if (UIGameMenu.gameObject.activeInHierarchy)
        {
            UIGameMenu.CloseGameMenu();
        }
        else
        {
            UIGameMenu.OpenGameMenu();
        }
    }
}
