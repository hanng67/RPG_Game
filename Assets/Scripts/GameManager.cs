using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CharStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingBetweenAreas;

    public string[] itemsHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
        SortItems();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController.Instance.CanMove = !(gameMenuOpen || dialogActive || fadingBetweenAreas);
    }

    public Item GetItemDetails(string itemToGrab)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].ItemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }

        return null;
    }

    public void SortItems()
    {
        // Follow tutorial
        //bool itemAfterSpace = true;

        //while (itemAfterSpace)
        //{
        //    itemAfterSpace = false;
        //    for (int i = 0; i < itemsHeld.Length-1; i++)
        //    {
        //        if(itemsHeld[i] == "")
        //        {
        //            itemsHeld[i] = itemsHeld[i + 1];
        //            itemsHeld[i + 1] = "";

        //            numberOfItems[i] = numberOfItems[i + 1];
        //            numberOfItems[i + 1] = 0;

        //            if(itemsHeld[i] != "")
        //            {
        //                itemAfterSpace = true;
        //            }
        //        }
        //    }
        //}

        for (int i = 0; i < itemsHeld.Length - 1; i++)
        {
            if (itemsHeld[i] != "") continue;

            for (int j = i + 1; j < itemsHeld.Length; j++)
            {
                if (itemsHeld[j] == "") continue;

                SwapItems(i, j);
                break;
            }
        }
    }

    private void SwapItems(int firstIdx, int secondIdx)
    {
        itemsHeld[firstIdx] = itemsHeld[secondIdx];
        itemsHeld[secondIdx] = "";

        numberOfItems[firstIdx] = numberOfItems[secondIdx];
        numberOfItems[secondIdx] = 0;
    }

    public void AddItem(string itemToAdd)
    {
        if (itemToAdd == "") return;

        int newItemPosition = System.Array.FindIndex<string>(itemsHeld, (string e) => e == itemToAdd || e == "");

        if (System.Array.Exists<Item>(referenceItems, (Item e) => e.ItemName == itemToAdd))
        {
            itemsHeld[newItemPosition] = itemToAdd;
            numberOfItems[newItemPosition]++;
        }
        else
        {
            Debug.LogError(itemToAdd + " Does Not Exist!");
        }

        GameMenu.Instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        if (itemToRemove == "") return;

        int itemPosition = System.Array.IndexOf(itemsHeld, itemToRemove);

        if (itemPosition != -1)
        {
            numberOfItems[itemPosition]--;

            if (numberOfItems[itemPosition] <= 0)
            {
                itemsHeld[itemPosition] = "";
            }

            GameMenu.Instance.ShowItems();
        }
        else
        {
            Debug.LogError("Couldn't Find " + itemToRemove);
        }
    }
}
