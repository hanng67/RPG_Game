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
}
