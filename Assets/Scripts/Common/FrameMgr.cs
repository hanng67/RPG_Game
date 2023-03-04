using UnityEngine;
using UnityEngine.UI;

public class FrameMgr : MonoBehaviour
{
    public static FrameMgr Instance;
    public Sprite[] BaseEquipmentSlots = new Sprite[6];

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}