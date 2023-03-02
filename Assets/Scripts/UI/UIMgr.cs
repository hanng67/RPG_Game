using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr Instance;

    [SerializeField] private List<GameObject> UIObjectPrefab = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        LoadUIObject();
        DontDestroyOnLoad(gameObject);
    }

    private void LoadUIObject()
    {
        foreach (var ui in UIObjectPrefab)
        {
            Instantiate(ui, transform);
        }
    }
}
