using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject theMenu;

    [SerializeField]
    private GameObject[] windows;

    private CharStats[] playerStats;

    [SerializeField]
    private GameObject charInfoContainer;
    [SerializeField]
    private CharacterInfo[] charInfos;

    [SerializeField]
    private GameObject[] statusButton;

    [SerializeField]
    private Text statusName, statusHP, statusMP, statusStrengh, statusDefence, statusWpnEqpd, statusWnpPwr, statusArmrEqpd, statusArmrPwr, statusExp;

    [SerializeField]
    private Image statusImage;

    public ItemButton[] ItemButtons;
    public string SelectedItem;
    public ItemClone ActiveItem;
    public Text ItemName, ItemDescription, UseBtnText;

    public GameObject ItemCharChoiceMenu;
    public Text[] ItemCharChoiceNames;

    public static GameMenu Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (theMenu.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStat();
                GameManager.Instance.gameMenuOpen = true;
            }
        }
    }

    void UpdateMainStat()
    {
        playerStats = GameManager.Instance.playerStats;

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                charInfos[i].gameObject.SetActive(true);
                charInfos[i].UpdateCharacterInfo(playerStats[i]);
            }
            else
            {
                charInfos[i].gameObject.SetActive(false);
            }
        }
    }

    public void ToggleWindows(int windowNumber)
    {
        UpdateMainStat();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        theMenu.SetActive(false);
        GameManager.Instance.gameMenuOpen = false;
    }

    public void OpenStatus()
    {
        UpdateMainStat();

        // update the information that is show
        StatusChar(0);

        for (int i = 0; i < statusButton.Length; i++)
        {
            statusButton[i].SetActive(playerStats[i].gameObject.activeInHierarchy);

            statusButton[i].GetComponentInChildren<Text>().text = playerStats[i].CharName;
        }
    }

    public void StatusChar(int selected)
    {
        statusName.text = playerStats[selected].CharName;
        statusHP.text = "" + playerStats[selected].CurrentHP + "/" + playerStats[selected].MaxHP;
        statusMP.text = "" + playerStats[selected].CurrentMP + "/" + playerStats[selected].MaxMP;
        statusStrengh.text = playerStats[selected].Strengh.ToString();
        statusDefence.text = playerStats[selected].Defence.ToString();
        statusWpnEqpd.text = playerStats[selected].EquippedWpn == "" ? "None" : playerStats[selected].EquippedWpn;
        statusWnpPwr.text = playerStats[selected].WpnPwr.ToString();
        statusArmrEqpd.text = playerStats[selected].EquippedArmr == "" ? "None" : playerStats[selected].EquippedArmr;
        statusArmrPwr.text = playerStats[selected].ArmrPwr.ToString();
        statusExp.text = (playerStats[selected].ExpToNextLevel[playerStats[selected].PlayerLevel] - playerStats[selected].CurrentExp).ToString();
        statusImage.sprite = playerStats[selected].CharImage;
    }

    public void ShowItems()
    {
        GameManager.Instance.SortItems();

        // for (int i = 0; i < ItemButtons.Length; i++)
        // {
        //     ItemButtons[i].buttonValue = i;

        //     if (GameManager.Instance.itemsHeld[i] != "")
        //     {
        //         ItemButtons[i].buttonImage.gameObject.SetActive(true);
        //         ItemButtons[i].buttonImage.sprite = GameManager.Instance.GetItemDetails(GameManager.Instance.itemsHeld[i]).ItemSprite;
        //         ItemButtons[i].amountText.text = GameManager.Instance.numberOfItems[i].ToString();
        //     }
        //     else
        //     {
        //         ItemButtons[i].buttonImage.gameObject.SetActive(false);
        //         ItemButtons[i].amountText.text = "";
        //     }
        // }
    }

    public void SelectItem(ItemClone newItem)
    {
        ActiveItem = newItem;
        if (newItem == null) return;

        ItemName.text = ActiveItem.ItemName;
        ItemDescription.text = ActiveItem.Description;

        if (ActiveItem.IsItem)
        {
            UseBtnText.text = "Use";
        }
        if (ActiveItem.IsWeapon || ActiveItem.IsArmor)
        {
            UseBtnText.text = "Equip";
        }
    }

    public void DiscardItem()
    {
        if (ActiveItem != null)
        {
            GameManager.Instance.RemoveItem(ActiveItem.name);
        }
    }

    public void OpenItemCharChoiceMenu()
    {
        ItemCharChoiceMenu.SetActive(true);
        for (int i = 0; i < ItemCharChoiceNames.Length; i++)
        {
            ItemCharChoiceNames[i].text = GameManager.Instance.playerStats[i].CharName;
            ItemCharChoiceNames[i].transform
                .parent.gameObject.SetActive(GameManager.Instance.playerStats[i].gameObject.activeInHierarchy);
        }
    }

    public void CloseItemCharChoiceMenu()
    {
        ItemCharChoiceMenu.SetActive(false);
    }

    public void UseItem(int selectChar){
        ActiveItem.Use(selectChar);
        CloseItemCharChoiceMenu();
    }
}
