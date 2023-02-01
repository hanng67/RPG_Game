using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public Text amountText;
    public int buttonValue;

    private Item _selectedItem = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {
        _selectedItem = null;

        if(GameManager.Instance.itemsHeld[buttonValue] != "")
        {
            _selectedItem = GameManager.Instance.GetItemDetails(GameManager.Instance.itemsHeld[buttonValue]);
        }

        GameMenu.Instance.SelectItem(_selectedItem);
    }
}
