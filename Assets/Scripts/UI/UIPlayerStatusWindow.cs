using UnityEngine;
using UnityEngine.UI;
using GameDefine;

public class UIPlayerStatusWindow : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text txtName;
    [SerializeField] private Text txtLV;
    [SerializeField] private Text txtHP;
    [SerializeField] private Text txtMP;
    [SerializeField] private Text txtEXP;
    [SerializeField] private Text txtATK;
    [SerializeField] private Text txtDEF;
    [SerializeField] private Text txtAGI;
    [SerializeField] private Text txtSTR;
    [SerializeField] private Text txtINT;
    [SerializeField] private Text txtSTA;
    [SerializeField] private Slider expSlider;

    [SerializeField] private GameObject eqptSlotContainer;
    [SerializeField] private GameObject eqptSlotPrefab;
    private PlayerInfo pInfo;

    private void Awake() {
        pInfo = PlayerMgr.Instance.PInfo;
    }
    
    private void Start() {
        for (int eqptType = 0; eqptType < (int)EquipmentTypes.Count; eqptType++)
        {
            GameObject eqptSlot = Instantiate(eqptSlotPrefab, eqptSlotContainer.transform);
            eqptSlot.GetComponent<UIEquipmentSlot>().Init((EquipmentTypes)eqptType, FrameMgr.Instance.DefaultEqptSlots[eqptType]);
        }
    }

    private void OnEnable() {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        txtName.text = pInfo.Name;
        icon.sprite = pInfo.Icon;
        txtLV.text = $"Lv: {pInfo.Stats[Attributes.Level]}";
        txtHP.text = $"HP: {pInfo.Stats[Attributes.Health_Restore]}/{pInfo.Stats[Attributes.Health]}";
        txtMP.text = $"MP: {pInfo.Stats[Attributes.Mana_Restore]}/{pInfo.Stats[Attributes.Mana]}";
        txtEXP.text = $"{pInfo.Stats[Attributes.Exp]}/{pInfo.ExpToNextLevel[pInfo.Stats[Attributes.Level]]}";
        txtATK.text = $"ATK: {pInfo.Stats[Attributes.Attack]}";
        txtDEF.text = $"DEF: {pInfo.Stats[Attributes.Defence]}";
        txtAGI.text = $"AGI: {pInfo.Stats[Attributes.Agility]}";
        txtSTR.text = $"STR: {pInfo.Stats[Attributes.Strength]}";
        txtINT.text = $"INT: {pInfo.Stats[Attributes.Intelligent]}";
        txtSTA.text = $"STA: {pInfo.Stats[Attributes.Stamina]}";
        expSlider.value = ((float)pInfo.Stats[Attributes.Exp])/pInfo.ExpToNextLevel[pInfo.Stats[Attributes.Level]];
    }
}
