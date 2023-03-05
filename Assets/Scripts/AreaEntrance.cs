using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string AreaEntranceName;

    // Start is called before the first frame update
    void Start()
    {
        if (AreaEntranceName == PlayerMgr.Instance.AreaTransistionName)
        {
            PlayerMgr.Instance.transform.position = transform.position;
        }
        UIFade.Instance.FadeFromBlack();
        GameManager.Instance.fadingBetweenAreas = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
