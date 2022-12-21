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

        if(GameManager.instance.itemsHeld[buttonValue] != "")
        {
            _selectedItem = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[buttonValue]);
        }

        GameMenu.instance.SelectItem(_selectedItem);
    }
}
