using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField]
    private Text nameText, hpText, mpText, lvlText, expText;

    [SerializeField]
    private Slider expSlider;

    [SerializeField]
    private Image charImage;

    public void UpdateCharacterInfo(CharStats charStat)
    {
        nameText.text = charStat.CharName;
        hpText.text = "HP: " + charStat.CurrentHP + "/" + charStat.MaxHP;
        mpText.text = "MP: " + charStat.CurrentMP + "/" + charStat.MaxMP;
        lvlText.text = "Lvl: " + charStat.PlayerLevel;
        expText.text = "" + charStat.CurrentExp + "/" + charStat.ExpToNextLevel[charStat.PlayerLevel];
        expSlider.maxValue = charStat.ExpToNextLevel[charStat.PlayerLevel];
        expSlider.value = charStat.CurrentExp;
        charImage.sprite = charStat.CharImage;
    }
}
