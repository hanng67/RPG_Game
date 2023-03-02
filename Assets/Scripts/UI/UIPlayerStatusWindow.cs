using UnityEngine;
using UnityEngine.UI;

public class UIPlayerStatusWindow : MonoBehaviour
{
    [SerializeField] private Text statusName;
    [SerializeField] private Text statusHP;
    [SerializeField] private Text statusMP;
    [SerializeField] private Text statusStrengh;
    [SerializeField] private Text statusDefence;
    [SerializeField] private Text statusWpnEqpd;
    [SerializeField] private Text statusWnpPwr;
    [SerializeField] private Text statusArmrEqpd;
    [SerializeField] private Text statusArmrPwr;
    [SerializeField] private Text statusExp;
    [SerializeField] private Image statusImage;
    private CharStats playerStats;

    public void UpdateInfo()
    {
        statusName.text = playerStats.CharName;
        statusHP.text = "" + playerStats.CurrentHP + "/" + playerStats.MaxHP;
        statusMP.text = "" + playerStats.CurrentMP + "/" + playerStats.MaxMP;
        statusStrengh.text = playerStats.Strengh.ToString();
        statusDefence.text = playerStats.Defence.ToString();
        statusWpnEqpd.text = playerStats.EquippedWpn == "" ? "None" : playerStats.EquippedWpn;
        statusWnpPwr.text = playerStats.WpnPwr.ToString();
        statusArmrEqpd.text = playerStats.EquippedArmr == "" ? "None" : playerStats.EquippedArmr;
        statusArmrPwr.text = playerStats.ArmrPwr.ToString();
        statusExp.text = (playerStats.ExpToNextLevel[playerStats.PlayerLevel] - playerStats.CurrentExp).ToString();
        statusImage.sprite = playerStats.CharImage;
    }
}
