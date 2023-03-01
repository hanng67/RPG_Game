using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string AreaEntranceName;

    // Start is called before the first frame update
    void Start()
    {
        if (AreaEntranceName == PlayerController.Instance.AreaTransistionName)
        {
            PlayerController.Instance.transform.position = transform.position;
        }
        UIMgr.Instance.UIFadeSystem.FadeFromBlack();
        GameManager.Instance.fadingBetweenAreas = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
